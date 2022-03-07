namespace LaserBrainTwister.Domain.Nodes;

[DebuggerDisplay("Number = {Number}")]
public class Node<T>
{
    public int Number { get; }
    public List<Node<T>> LinkedNodes { get; } = new();
    public T Item { get; }

    public Node(T item, int number)
    {
        Item = item;
        Number = number;
        LinkedNodes = new();
    }

    internal void LinkNode(Node<T> node) => LinkedNodes.Add(node);
}

