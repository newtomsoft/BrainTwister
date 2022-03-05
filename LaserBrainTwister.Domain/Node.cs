namespace LaserBrainTwister.Domain;

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

    public Node(Node node)
    {
        Number = node.Number;
        foreach (var linkedNode in node.LinkedNodes) LinkedNodes.Add(new Node(linkedNode));
    }

    internal void LinkNode(Node node) => LinkedNodes.Add(node);
}


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

    public Node(Node<T> node)
    {
        Item = node.Item;
        Number = node.Number;
        foreach (var linkedNode in node.LinkedNodes) LinkedNodes.Add(new Node<T>(linkedNode));
    }

    internal void LinkNode(Node<T> node) => LinkedNodes.Add(node);
}

