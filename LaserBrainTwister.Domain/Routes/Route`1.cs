namespace LaserBrainTwister.Domain.Routes;

[DebuggerDisplay("{ToString()}")]
public class Route<T>
{
    public readonly List<Node<T>> Nodes = new();

    public Route(Node<T> node) => AddNode(node);
    public Route(IEnumerable<Node<T>> nodes) => AddNodes(nodes);

    public void AddNode(Node<T> node) => Nodes.Add(node);

    private void AddNodes(IEnumerable<Node<T>> nodes) => Nodes.AddRange(nodes);

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        foreach (var node in Nodes)
        {
            stringBuilder.Append(node.Item);
            stringBuilder.Append(' ');
        }
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        return stringBuilder.ToString();
    }
}