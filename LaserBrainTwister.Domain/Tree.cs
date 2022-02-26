namespace LaserBrainTwister.Domain;

public class Tree
{
    public readonly List<Node> Nodes = new();

    public Tree(params int[] numbers) => AddNodes(numbers);

    public void AddNodes(params int[] numbers)
    {
        foreach (var number in numbers) Nodes.Add(Node.New(number));
    }

    public Segment LinkFrom(int fromNodeNumber, int toNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        var toNode = Nodes.FirstOrDefault(n => n.Number == toNodeNumber);
        if (fromNode is null) throw new ArgumentException("segment from doesn't exist");
        if (toNode is null) throw new ArgumentException("segment to doesn't exist");
        fromNode.AddLinkedNode(toNode);
        return new Segment(fromNode, toNode, this);
    }

    public Segment LinkFrom(int fromNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        return fromNode is null ? throw new ArgumentException("segment from doesn't exist") : new Segment(fromNode, Node.New(0), this);
    }

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
