namespace LaserBrainTwister.Domain;

public class Tree
{
    public readonly List<Node> Nodes = new();

    public Tree(int nodesNumber) => AddNodes(nodesNumber);

    public void AddNodes(int number) => Nodes.AddRange(Enumerable.Range(0, number).Select(n => Node.New(n)));


    /// <summary>
    /// To link 2 nodes. Use Segment.To Method immediatly after this
    /// </summary>
    /// <param name="fromNodeNumber"></param>
    /// <returns>begin of the segment used to link 2 nodes</returns>
    /// <exception cref="ArgumentException"></exception>
    public Segment LinkFrom(int fromNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        return fromNode is null ? throw new ArgumentException("segment 'from' doesn't exist") : Segment.New(fromNode, Node.New(0), this);
    }

    /// <summary>
    /// Get all possibles route from first node to all nodes that have no linked node
    /// </summary>
    /// <returns></returns>
    public List<Route> GetRoutes()
    {
        var beginTree = new Route();
        beginTree.AddNode(Nodes.First());
        return GetRoutes(beginTree);
    }

    private static List<Route> GetRoutes(Route beginTree)
    {
        var result = new List<Route>();
        var nodeOrigin = beginTree.Nodes.Last();
        if (nodeOrigin.LinkedNodes.Count == 0)
        {
            var browsedTree = new Route();
            browsedTree.AddNodes(beginTree.Nodes);
            return new List<Route> { browsedTree };
        }
        foreach (var node in nodeOrigin.LinkedNodes)
        {
            if (beginTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var browsedTree = new Route();
            browsedTree.AddNodes(beginTree.Nodes);
            browsedTree.AddNode(node);
            result.AddRange(GetRoutes(browsedTree));
        }
        return result;
    }
}
