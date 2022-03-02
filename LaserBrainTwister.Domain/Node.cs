namespace LaserBrainTwister.Domain;

public class Node
{
    public int Number { get; }
    public List<Node> LinkedNodes { get; } = new();

    public Node(int number)
    {
        Number = number;
        LinkedNodes = new();
    }

    public Node(Node node)
    {
        Number = node.Number;
        foreach (var currentNode in node.LinkedNodes)
        {
            LinkedNodes.Add(new Node(currentNode));
        }
    }

    internal void LinkNode(Node node) => LinkedNodes.Add(node);
}
