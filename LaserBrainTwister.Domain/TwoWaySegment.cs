namespace LaserBrainTwister.Domain;

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
            To(nodeTo);
            segment = new TwoWaySegment(_start, nodeTo, _tree);
            segment.Then(_start.Number);
        }
        return segment;
    }

    public ISegment Then(params int[] nodesNumber)
    {
        if (nodesNumber.Length == 0) throw new ArgumentException("enter at least one node number");
        var segment = Reverse();
        foreach (var node in nodesNumber)
        {
            segment = segment.To(node).Reverse();
        }
        return segment.Reverse();
    }

    public ISegment NextTo(params int[] nodesNumber) => Next().To(nodesNumber);
    public ISegment Reverse() => new TwoWaySegment(_end, _start, _tree);

    private TwoWaySegment To(Node node)
    {
        _start.LinkNode(node);
        return new(_start, node, _tree);
    }

    private TwoWaySegment Then(Node node)
    {
        _end.LinkNode(node);
        return new(_end, node, _tree);
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
        To(nodeTo);
        segment = new TwoWaySegment<T>(_start, nodeTo, _tree);
        segment.Then(item, _start.Number);

        return segment;
    }

    public ISegment<T> Then(T item, int nodeNumber)
    {
        var segment = Reverse();
        segment = segment.To(item, nodeNumber).Reverse();
        return segment.Reverse();
    }

    public ISegment<T> NextTo(T currentItem, T item, int nodeNumber) => Next(currentItem).To(item, nodeNumber);
    public ISegment<T> Reverse() => new TwoWaySegment<T>(_end, _start, _tree);

    private TwoWaySegment<T> To(Node<T> node)
    {
        _start.LinkNode(node);
        return new(_start, node, _tree);
    }

    private TwoWaySegment<T> Then(Node<T> node)
    {
        _end.LinkNode(node);
        return new(_end, node, _tree);
    }

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
}