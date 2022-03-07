namespace LaserBrainTwister.Domain.Segments;

public class TwoWaySegment<T> : ISegment<T>
{
    private readonly Node<T> _start;
    private readonly Node<T> _end;
    private readonly ITree<T> _tree;

    public TwoWaySegment(Node<T> start, Node<T> end, ITree<T> tree)
    {
        _start = start;
        _end = end;
        _tree = tree;
    }

    public ISegment<T> To(T item, int nodeNumber)
    {
        ISegment<T> segment = this;

        var nodeTo = _tree.Nodes.FirstOrDefault(n => n.Number == nodeNumber);
        if (nodeTo is not null && _start.LinkedNodes.Contains(nodeTo)) return segment;
        if (nodeTo is null)
        {
            nodeTo = new Node<T>(item, nodeNumber);
            _tree.Nodes.Add(nodeTo);
        }
        segment = To(nodeTo);
        segment.Then(item, _start.Number);
        return segment;
    }

    public void Then(T item, int nodeNumber) => Reverse().To(item, nodeNumber);

    public ISegment<T> Next(T item)
    {
        var startNumber = _start.Number + 1;
        var startNode = _tree.Nodes.FirstOrDefault(n => n.Number == startNumber);
        if (startNode is null)
        {
            startNode = new Node<T>(item, startNumber);
            _tree.Nodes.Add(startNode);
        }

        return new TwoWaySegment<T>(startNode, new(default, 0), _tree);
    }

    private ISegment<T> Reverse() => new TwoWaySegment<T>(_end, _start, _tree);

    private TwoWaySegment<T> To(Node<T> node)
    {
        _start.LinkNode(node);
        return new(_start, node, _tree);
    }
}