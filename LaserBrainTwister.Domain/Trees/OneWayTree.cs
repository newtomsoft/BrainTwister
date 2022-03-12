namespace LaserBrainTwister.Domain.Trees;

public class OneWayTree<T> : ITree<T> where T : IEquatable<T>
{
    public List<Node<T>> Nodes { get; } = new();

    public int NodesNumber() => Nodes.Count;

    public ISegment<T> LinkFrom(T item)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Item.Equals(item));
        return fromNode is null
            ? new OneWaySegment<T>(AddNode(item, Nodes.Any() ? Nodes.Max(n => n.Id) + 1 : 0), new(item, 0), this)
            : new OneWaySegment<T>(fromNode, new(item, 0), this);
    }

    public IEnumerable<Route<T>> GetRoutes(bool bruteForce = false)
    {
        if (bruteForce is not true) OptimizeRoutes();
        var route = new Route<T>(Nodes.First());
        foreach (var currentRoute in GetRoutesToDeadEnd(route))
            yield return currentRoute;
    }

    public IEnumerable<Route<T>> GetRoutesWithAllNodes(bool bruteForce = false) => GetRoutes(bruteForce).Where(r => r.NodesNumber() == NodesNumber());

    public Route<T>? GetRouteWithMostNodes() => GetRoutes(true).OrderByDescending(r => r.NodesNumber()).FirstOrDefault();

    public Route<T>? GetRouteWithLeastNodes() => GetRoutes(true).OrderBy(r => r.NodesNumber()).FirstOrDefault();

    public List<Route<T>> OptimizeRoutes() => throw new NotSupportedException();

    private static IEnumerable<Route<T>> GetRoutesToDeadEnd(Route<T> startTree)
    {
        var startNode = startTree.Nodes.Last();
        if (startNode.LinkedNodes.Count == 0 && startTree.NodesNumber() > 1)
            yield return new Route<T>(startTree.Nodes);

        foreach (var node in startNode.LinkedNodes)
        {
            if (startTree.Nodes.Any(n => n.Id == node.Id)) continue;
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