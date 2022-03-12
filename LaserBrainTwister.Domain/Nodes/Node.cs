namespace LaserBrainTwister.Domain.Nodes;

[DebuggerDisplay("Id = {Id}")]
public class Node<T>
{
    public int Id { get; }
    public List<Node<T>> LinkedNodes { get; }
    public T Item { get; }

    public Node(T item, int id)
    {
        Item = item;
        Id = id;
        LinkedNodes = new();
    }

    internal void LinkNode(Node<T> node) => LinkedNodes.Add(node);
}

