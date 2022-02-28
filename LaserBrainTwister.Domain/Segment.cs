namespace LaserBrainTwister.Domain;

public class Segment
{
    private readonly Node _begin;
    private readonly Node _end;
    private readonly Tree _tree;

    public static Segment New(Node begin, Node end, Tree tree) => new(begin, end, tree);

    private Segment(Node begin, Node end, Tree tree)
    {
        _begin = begin;
        _end = end;
        _tree = tree;
    }

    /// <summary>
    /// Add link from begin of segment to parameter nodes number
    /// </summary>
    /// <param name="nodesNumbers"></param>
    /// <returns>new segment create by begin to last node</returns>
    public Segment To(params int[] nodesNumber)
    {
        if (nodesNumber.Length == 0) throw new ArgumentException("enter at least one node number");
        foreach (var nodeNumber in nodesNumber) To(_tree.Nodes.Single(n => n.Number == nodeNumber));
        return Segment.New(_begin, _tree.Nodes.Single(n => n.Number == nodesNumber.Last()), _tree);
    }

    /// <summary>
    /// Add link from end of segment successively to parameter node number
    /// </summary>
    /// <param name="nodeNumber"></param>
    /// <returns>new segment create</returns>
    public Segment Then(params int[] nodesNumber)
    {
        if (nodesNumber.Length == 0) throw new ArgumentException("enter at least one node number");
        var segment = this;
        foreach (var nodeNumber in nodesNumber)
            segment = segment.Then(_tree.Nodes.Single(n => n.Number == nodeNumber));

        return Segment.New(_end, _tree.Nodes.Single(n => n.Number == nodesNumber.Last()), _tree);
    }

    /// <summary>
    /// Select Segment that begin by next Number. End segment is undefined.
    /// Use it with "Segment.To() after it"
    /// </summary>
    /// <returns></returns>
    public Segment Next()
    {
        var beginNumber = _begin.Number + 1;
        var beginNode = _tree.Nodes.First(n => n.Number == beginNumber);
        return New(beginNode, Node.New(0), _tree);
    }

    private Segment To(Node LinkedNode)
    {
        _begin.AddLinkedNode(LinkedNode);
        return New(_begin, LinkedNode, _tree);
    }

    private Segment Then(Node LinkedNode)
    {
        _end.AddLinkedNode(LinkedNode);
        return New(_end, LinkedNode, _tree);
    }
}
