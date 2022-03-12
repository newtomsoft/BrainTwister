namespace LaserBrainTwister.Domain.Segments;

public class OneWaySegment<T> : ISegment<T> where T : IEquatable<T>
{
    private readonly Node<T> _start;
    private readonly Node<T> _end;
    private readonly ITree<T> _tree;

    public OneWaySegment(Node<T> start, Node<T> end, ITree<T> tree)
    {
        _start = start;
        _end = end;
        _tree = tree;
    }

    public ISegment<T> To(T item)
    {
        var nodeTo = _tree.Nodes.FirstOrDefault(n => n.Item.Equals(item));
        if (nodeTo is not null && _start.LinkedNodes.Contains(nodeTo)) return this;
        if (nodeTo is null)
        {
            var id = _tree.Nodes.Max(n => n.Id) + 1;
            nodeTo = new Node<T>(item, id);
            _tree.Nodes.Add(nodeTo);
        }
        return To(nodeTo);
    }

    public ISegment<T> Then(T item) =>  Reverse().To(item);

    public ISegment<T> Next(T item)
    {
        var startNode = _tree.Nodes.FirstOrDefault(n => n.Item.Equals(item));
        if (startNode is null)
        {
            startNode = new Node<T>(item, _tree.Nodes.Max(n => n.Id) + 1);
            _tree.Nodes.Add(startNode);
        }

        return new OneWaySegment<T>(startNode, new(default, 0), _tree);
    }

    private ISegment<T> Reverse() => new OneWaySegment<T>(_end, _start, _tree);

    private OneWaySegment<T> To(Node<T> node)
    {
        _start.LinkNode(node);
        return new(_start, node, _tree);
    }
}