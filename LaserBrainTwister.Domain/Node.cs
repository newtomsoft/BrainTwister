namespace LaserBrainTwister.Domain;

public class Node
{
    public int Number { get; }
    public List<Node> LinkedNodes { get; }

    public static Node New(int number) => new(number);

    private Node(int number)
    {
        Number = number;
        LinkedNodes = new();
    }

    internal void AddLinkedNode(Node node) => LinkedNodes.Add(node);
}
