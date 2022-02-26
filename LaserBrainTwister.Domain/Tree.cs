namespace LaserBrainTwister.Domain;

public class Tree
{
    public readonly List<Node> Nodes = new();

    public Tree(params int[] numbers) => AddNodes(numbers);

    public void AddNodes(params int[] numbers)
    {
        foreach (var number in numbers) Nodes.Add(Node.New(number));
    }

    public void AddNodes(Range range)
    {
        for (int number = range.Start.Value; number <= range.End.Value; number++)
            Nodes.Add(Node.New(number));
    }

    public void AddLink(int fromNodeNumber, int toNodeNumber)
    {
        var fromNode = Nodes.FirstOrDefault(n => n.Number == fromNodeNumber);
        var toNode = Nodes.FirstOrDefault(n => n.Number == toNodeNumber);
        if (fromNode is null || toNode is null) return;
        fromNode.AddLinkedNode(toNode);
    }

    public List<Route> TreeRoutes()
    {
        var beginTree = new Route();
        beginTree.Nodes.Add(Nodes[0]);
        return TreeRoutes(beginTree);
    }

    private static List<Route> TreeRoutes(Route beginTree)
    {
        var result = new List<Route>();
        var nodeOrigin = beginTree.Nodes.Last();
        if (nodeOrigin.LinkedNodes.Count == 0)
        {
            var browsedTree = new Route();
            browsedTree.Nodes.AddRange(beginTree.Nodes);
            return new List<Route> { browsedTree };
        }

        foreach (var node in nodeOrigin.LinkedNodes)
        {
            if (beginTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var browsedTree = new Route();
            browsedTree.Nodes.AddRange(beginTree.Nodes);
            browsedTree.Nodes.Add(node);
            result.AddRange(TreeRoutes(browsedTree));
        }
        return result;
    }
}
