namespace LaserBrainTwister.Domain;

public class Node
{
    public static readonly List<Node> AllNodes = new();
    public int Number { get; }
    public List<int> LinkedNodeNumbers { get; private set; }


    public static Node New(int number)
    {
        var node = NodeFromNumber(number);
        return node is null ? new Node(number) : node;
    }

    public static Node? NodeFromNumber(int number) => AllNodes.FirstOrDefault(n => n.Number == number);

    protected Node(int number)
    {       
        AllNodes.Add(this);
        Number = number;
        LinkedNodeNumbers = new();
    }

    public Node(int number, List<int> linkedNodesNumber) : this(number)
    {
        LinkedNodeNumbers = linkedNodesNumber;
    }

    public void AddLinkedNode(int nodeNumber)
    {
        if (NodeFromNumber(nodeNumber) is not null) LinkedNodeNumbers.Add(nodeNumber);
        else
        {
            _ = new Node(nodeNumber);
            AddLinkedNode(nodeNumber);
        }
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