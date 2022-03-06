namespace LaserBrainTwister.Domain.Tree;

public class TwoWayTree : ITree
{
    public List<Node.Node> Nodes { get; } = new();

    public ISegment LinkFrom(int fromNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        return fromNode is null ? new TwoWaySegment(AddNode(fromNodeNumber), new(0), this) : new TwoWaySegment(fromNode, new(0), this);
    }
    public ISegment LinkFromOriginTo(params int[] nodesNumber) => LinkFrom(0).To(nodesNumber);

    public IEnumerable<Route.Route> GetRoutesFromStartToDeadEnds()
    {
        var route = new Route.Route(Nodes.First());
        foreach (var currentRoute in GetRoutesToDeadEnd(route))
            yield return currentRoute;
    }

    private static IEnumerable<Route.Route> GetRoutesToDeadEnd(Route.Route startTree)
    {
        var startNode = startTree.Nodes.Last();
        if (startNode.LinkedNodes.Count == 1)
            yield return new Route.Route(startTree.Nodes);

        foreach (var node in startNode.LinkedNodes)
        {
            if (startTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var route = new Route.Route(startTree.Nodes);
            route.AddNode(node);
            foreach (var suitRoute in GetRoutesToDeadEnd(route))
                yield return suitRoute;
        }
    }

    private Node.Node AddNode(int number)
    {
        var node = new Node.Node(number);
        Nodes.Add(node);
        return node;
    }
}
