namespace LaserBrainTwister.Domain;

public class Segment
{
    public Node Begin;
    public Node End;
    private readonly Tree _tree;

    static Segment From(Node begin, Node end, Tree tree) => new(begin, end, tree);
    public Segment(Node begin, Node end, Tree tree)
    {
        Begin = begin;
        End = end;
        _tree = tree;
    }

    public Segment And(Node LinkedNode)
    {
        Begin.AddLinkedNode(LinkedNode);
        return From(Begin, LinkedNode, _tree);
    }

    public Segment And(int nodeNumber)
    {
        var node = _tree.Nodes.Single(n => n.Number == nodeNumber);
        return And(node);
    }

    public Segment Then(Node LinkedNode)
    {
        End.AddLinkedNode(LinkedNode);
        return From(End, LinkedNode, _tree);
    }

}
