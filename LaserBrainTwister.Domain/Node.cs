namespace LaserBrainTwister.Domain;


public class Node
{
    public int Number { get; }
    public List<Node> LinkedNodes { get; private set; }

    public static Node New(int number) => new Node(number);

    private Node(int number)
    {
        Number = number;
        LinkedNodes = new();
    }

    public void AddLinkedNode(Node node) => LinkedNodes.Add(node);
}
