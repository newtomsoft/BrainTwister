namespace LaserBrainTwister.Domain.Trees;

public class Tree : ITree
{
    public List<Node> Nodes { get; } = new();

    /// <summary>
    /// To link 2 nodes. Use Segment.To() immediately after this
    /// </summary>
    /// <param name="fromNodeNumber"></param>
    /// <returns>begin of the segment used to link 2 nodes</returns>
    /// <exception cref="ArgumentException"></exception>
    public ISegment LinkFrom(int fromNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        return fromNode is null ? new Segment(AddNode(fromNodeNumber), new(0), this) : new(fromNode, new(0), this);
    }

    public ISegment LinkFromOriginTo(params int[] nodesNumber) => LinkFrom(0).To(nodesNumber);


    /// <summary>
    /// Get all possibles routes from first node to all nodes that have no linked node
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Routes.Route> GetRoutesFromStartToDeadEnds()
    {
        var route = new Routes.Route(Nodes.First());
        foreach (var currentRoute in GetRoutesToDeadEnd(route))
            yield return currentRoute;
    }

    private static IEnumerable<Routes.Route> GetRoutesToDeadEnd(Routes.Route startTree)
    {
        var startNode = startTree.Nodes.Last();
        if (startNode.LinkedNodes.Count == 0)
            yield return new Routes.Route(startTree.Nodes);

        foreach (var node in startNode.LinkedNodes)
        {
            if (startTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var route = new Routes.Route(startTree.Nodes);
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
