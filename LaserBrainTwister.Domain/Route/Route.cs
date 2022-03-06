namespace LaserBrainTwister.Domain.Route;

public class Route
{
    public readonly List<Node.Node> Nodes = new();

    public Route(Node.Node node) => AddNode(node);
    public Route(IEnumerable<Node.Node> nodes) => AddNodes(nodes);

    public void AddNode(Node.Node node) => Nodes.Add(node);
    private void AddNodes(IEnumerable<Node.Node> nodes) => Nodes.AddRange(nodes);

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        foreach (var node in Nodes)
        {
            stringBuilder.Append(node.Number);
            stringBuilder.Append(' ');
        }
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        return stringBuilder.ToString();
    }
}
