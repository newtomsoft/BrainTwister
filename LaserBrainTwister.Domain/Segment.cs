namespace LaserBrainTwister.Domain;

public class Segment : ISegment
{
    private readonly Node _start;
    private readonly Node _end;
    private readonly Tree _tree;

    public Segment(Node start, Node end, Tree tree)
    {
        _start = start;
        _end = end;
        _tree = tree;
    }

    /// <summary>
    /// Add link from begin of segment to parameter nodes number
    /// </summary>
    /// <param name="nodesNumber"></param>
    /// <returns>new segment create by begin to last node</returns>
    public ISegment To(params int[] nodesNumber)
    {
        if (nodesNumber.Length == 0) throw new ArgumentException("enter at least one node number");
        foreach (var nodeNumber in nodesNumber)
        {
            var nodeTo = _tree.Nodes.FirstOrDefault(n => n.Number == nodeNumber);
            if (nodeTo is null)
            {
                nodeTo = new Node(nodeNumber);
                _tree.Nodes.Add(nodeTo);
            }
            To(nodeTo);
        }
        var endNode = _tree.Nodes.Single(n => n.Number == nodesNumber.Last());
        return new Segment(_start, endNode, _tree);
    }

    /// <summary>
    /// Add link from end of segment successively to parameter node number
    /// </summary>
    /// <param name="nodesNumber"></param>
    /// <returns>new segment create</returns>
    public ISegment Then(params int[] nodesNumber)
    {
        if (nodesNumber.Length == 0) throw new ArgumentException("enter at least one node number");
        var segment = Reverse();
        foreach (var node in nodesNumber)
            segment = segment.To(node).Reverse();

        return segment.Reverse();
    }

    /// <summary>
    /// Select Segment that begin by next Number. End segment is undefined.
    /// Use it with "Segment.To() after it"
    /// </summary>
    /// <returns></returns>
    public ISegment Next()
    {
        var startNumber = _start.Number + 1;
        var startNode = _tree.Nodes.FirstOrDefault(n => n.Number == startNumber);
        if (startNode is null)
        {
            startNode = new Node(startNumber);
            _tree.Nodes.Add(startNode);
        }
        return new Segment(startNode, new(0), _tree);
    }
    
    public ISegment NextTo(params int[] nodesNumber) => Next().To(nodesNumber);
    public ISegment Reverse() => new Segment(_end, _start, _tree);

    private Segment To(Node node)
    {
        _start.LinkNode(node);
        return new(_start, node, _tree);
    }
}
