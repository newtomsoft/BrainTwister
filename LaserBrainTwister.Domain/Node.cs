namespace LaserBrainTwister.Domain;


public class BrowsedTree
{
    public readonly List<Node> Nodes = new();
}

public class NodeTree
{
    public readonly List<Node> Nodes = new();

    public void AddNode(int number) => Nodes.Add(Node.New(number));


    public List<BrowsedTree> BrowseNodes()
    {
        var beginTree = new BrowsedTree();
        beginTree.Nodes.Add(Nodes[0]);
        return BrowseNodes(beginTree);
    }

    private static List<BrowsedTree> BrowseNodes(BrowsedTree beginTree)
    {
        var result = new List<BrowsedTree>();
        var nodeOrigin = beginTree.Nodes.Last();
        if (nodeOrigin.LinkedNodes.Count == 0)
        {
            var browsedTree = new BrowsedTree();
            browsedTree.Nodes.AddRange(beginTree.Nodes);
            return new List<BrowsedTree> { browsedTree };
        }

        foreach (var node in nodeOrigin.LinkedNodes)
        {
            if (beginTree.Nodes.Any(n => n.Number == node.Number)) continue;
            var browsedTree = new BrowsedTree();
            browsedTree.Nodes.AddRange(beginTree.Nodes);
            browsedTree.Nodes.Add(node);
            result.AddRange(BrowseNodes(browsedTree));
        }
        return result;
    }


    private Node? NodeFromNumber(int number) => Nodes.FirstOrDefault(n => n.Number == number);
}


public class Node
{
    public int Number { get; }
    public List<Node> LinkedNodes { get; private set; }


    public static Node New(int number) => new Node(number);



    protected Node(int number)
    {
        Number = number;
        LinkedNodes = new();
    }

    public void AddLinkedNode(Node node)
    {
        LinkedNodes.Add(node);
    }
}


//public class FirstNode : Node
//{
//    public FirstNode() : base(0)
//    {

//    }
//}

//public class LastNode : Node
//{
//    public LastNode(int number) : base(number)
//    {
//        LinkedNodes = new();
//    }
//}