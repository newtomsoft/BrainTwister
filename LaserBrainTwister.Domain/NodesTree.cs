namespace LaserBrainTwister.Domain;

public class NodesTree
{
    public readonly List<Node> Nodes = new();

    public NodesTree(params int[] numbers) => AddNodes(numbers);

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

    public List<TreeRoute> TreeRoutes()
    {
        var beginTree = new TreeRoute();
        beginTree.Nodes.Add(Nodes[0]);
        return TreeRoutes(beginTree);
    }

    private static List<TreeRoute> TreeRoutes(TreeRoute beginTree)
    {
        var result = new List<TreeRoute>();
        var nodeOrigin = beginTree.Nodes.Last();
        if (nodeOrigin.LinkedNodes.Count == 0)
        {
            var browsedTree = new TreeRoute();
            browsedTree.Nodes.AddRange(beginTree.Nodes);
            return new List<TreeRoute> { browsedTree };
        }

        foreach (var node in nodeOrigin.LinkedNodes)
        {
            if (beginTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var browsedTree = new TreeRoute();
            browsedTree.Nodes.AddRange(beginTree.Nodes);
            browsedTree.Nodes.Add(node);
            result.AddRange(TreeRoutes(browsedTree));
        }
        return result;
    }
}
