﻿using System.Text;

namespace LaserBrainTwister.Domain;

public class Route
{
    public readonly List<Node> Nodes = new();

    public void AddNode(Node node) => Nodes.Add(node);
    public void AddNodes(IEnumerable<Node> nodes) => Nodes.AddRange(nodes);

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        foreach (var node in Nodes)
        {
            stringBuilder.Append(node.Number.ToString());
            stringBuilder.Append(' ');
        }
        return stringBuilder.ToString();
    }
}