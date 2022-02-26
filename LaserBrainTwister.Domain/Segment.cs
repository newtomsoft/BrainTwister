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
    /// Add link from begin of segment to parameter node number
    /// </summary>
    /// <param name="nodeNumber"></param>
    /// <returns>new segment create by begin to this node</returns>
    public Segment To(int nodeNumber) => To(_tree.Nodes.Single(n => n.Number == nodeNumber));

    /// <summary>
    /// Add link from end of segment to parameter node number
    /// </summary>
    /// <param name="nodeNumber"></param>
    /// <returns>new segment create</returns>
    public Segment Then(int nodeNumber) => Then(_tree.Nodes.Single(n => n.Number == nodeNumber));

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
