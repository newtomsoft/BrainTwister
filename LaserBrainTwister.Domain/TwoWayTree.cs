namespace LaserBrainTwister.Domain;

public class TwoWayTree : ITree
{
    public List<Node> Nodes { get; } = new();

    public ISegment LinkFrom(int fromNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        return fromNode is null ? new TwoWaySegment(AddNode(fromNodeNumber), new(0), this) : new TwoWaySegment(fromNode, new(0), this);
    }
    public ISegment LinkFromOriginTo(params int[] nodesNumber) => LinkFrom(0).To(nodesNumber);

    public IEnumerable<Route> GetRoutesFromStartToDeadEnds()
    {
        var route = new Route(Nodes.First());
        foreach (var currentRoute in GetRoutesToDeadEnd(route))
            yield return currentRoute;
    }

    private static IEnumerable<Route> GetRoutesToDeadEnd(Route startTree)
    {
        var startNode = startTree.Nodes.Last();
        if (startNode.LinkedNodes.Count == 1)
            yield return new Route(startTree.Nodes);

        foreach (var node in startNode.LinkedNodes)
        {
            if (startTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var route = new Route(startTree.Nodes);
            route.AddNode(node);
            foreach (var suitRoute in GetRoutesToDeadEnd(route))
                yield return suitRoute;
        }
    }

    private Node AddNode(int number)
    {
        var node = new Node(number);
        Nodes.Add(node);
        return node;
    }
}

public class TwoWayTree<T> : ITree<T>
{
    public List<Node<T>> Nodes { get; } = new();

    public ISegment<T> LinkFrom(T item, int fromNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        return fromNode is null ? new TwoWaySegment<T>(AddNode(item, fromNodeNumber), new(item, 0), this) : new TwoWaySegment<T>(fromNode, new(item, 0), this);
    }
    public ISegment<T> LinkFromOriginTo(T item, int nodeNumber) => LinkFrom(item, 0).To(item, nodeNumber);

    public IEnumerable<Route<T>> GetRoutesFromStartToDeadEnds()
    {
        var route = new Route<T>(Nodes.First());
        foreach (var currentRoute in GetRoutesToDeadEnd(route))
            yield return currentRoute;
    }

    private static IEnumerable<Route<T>> GetRoutesToDeadEnd(Route<T> startTree)
    {
        var startNode = startTree.Nodes.Last();
        if (startNode.LinkedNodes.Count == 1 && startTree.Nodes.Count > 1)
            yield return new Route<T>(startTree.Nodes);

        foreach (var node in startNode.LinkedNodes)
        {
            if (startTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var route = new Route<T>(startTree.Nodes);
            route.AddNode(node);
            foreach (var suitRoute in GetRoutesToDeadEnd(route))
                yield return suitRoute;
        }
    }

    private Node<T> AddNode(T item, int number)
    {
        var node = new Node<T>(item, number);
        Nodes.Add(node);
        return node;
    }
}