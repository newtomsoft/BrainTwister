namespace LaserBrainTwister.Domain.Node;

[DebuggerDisplay("Number = {Number}")]
public class Node
{
    public int Number { get; }
    public List<Node> LinkedNodes { get; } = new();

    public Node(int number)
    {
        Number = number;
        LinkedNodes = new();
    }

    internal void LinkNode(Node node) => LinkedNodes.Add(node);
}
