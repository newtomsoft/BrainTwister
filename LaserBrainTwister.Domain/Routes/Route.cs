namespace LaserBrainTwister.Domain.Routes;

public class Route
{
    public readonly List<Node> Nodes = new();

    public int NodesNumber() => Nodes.Count;

    public Route(Node node) => AddNode(node);
    public Route(IEnumerable<Node> nodes) => AddNodes(nodes);

    public void AddNode(Node node) => Nodes.Add(node);
    private void AddNodes(IEnumerable<Node> nodes) => Nodes.AddRange(nodes);

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
