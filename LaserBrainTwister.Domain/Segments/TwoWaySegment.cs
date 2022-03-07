﻿namespace LaserBrainTwister.Domain.Segments;

public class TwoWaySegment : ISegment
{
    private readonly Node _start;
    private readonly Node _end;
    private readonly ITree _tree;

    public TwoWaySegment(Node start, Node end, ITree tree)
    {
        _start = start;
        _end = end;
        _tree = tree;
    }

    public ISegment To(params int[] nodesNumber)
    {
        if (nodesNumber.Length == 0) throw new ArgumentException("enter at least one node number");
        ISegment segment = this;
        foreach (var nodeNumber in nodesNumber)
        {
            var nodeTo = _tree.Nodes.FirstOrDefault(n => n.Number == nodeNumber);
            if (nodeTo is not null && _start.LinkedNodes.Contains(nodeTo)) continue;
            if (nodeTo is null)
            {
                nodeTo = new Node(nodeNumber);
                _tree.Nodes.Add(nodeTo);
            }
            segment = To(nodeTo);
            segment.Then(_start.Number);
        }
        return segment;
    }

    public ISegment Then(params int[] nodesNumber)
    {
        if (nodesNumber.Length == 0) throw new ArgumentException("enter at least one node number");
        var segment = Reverse();
        foreach (var node in nodesNumber) segment = segment.To(node).Reverse();
        return segment.Reverse();
    }

    public ISegment NextTo(params int[] nodesNumber) => Next().To(nodesNumber);
    public ISegment Reverse() => new TwoWaySegment(_end, _start, _tree);

    private TwoWaySegment To(Node node)
    {
        _start.LinkNode(node);
        return new(_start, node, _tree);
    }

    public ISegment Next()
    {
        var startNumber = _start.Number + 1;
        var startNode = _tree.Nodes.FirstOrDefault(n => n.Number == startNumber);
        if (startNode is null)
        {
            startNode = new Node(startNumber);
            _tree.Nodes.Add(startNode);
        }
        return new TwoWaySegment(startNode, new(0), _tree);
    }
}