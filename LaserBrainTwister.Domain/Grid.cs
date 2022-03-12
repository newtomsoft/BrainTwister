namespace LaserBrainTwister.Domain;

public class Grid
{
    public List<Coordinate> Nodes { get; } = new();

    private readonly HashSet<Coordinate> _errorNodes = new();
    private Coordinate? _startNode;
    private Coordinate? _endNode;

    public int GetEnableNodesNumber() => Nodes.Count;

    public bool IsEnable(Coordinate coordinate) => Nodes.Contains(coordinate);
    public bool IsError(Coordinate coordinate) => _errorNodes.Contains(coordinate);
    public void SetError(Coordinate coordinate) => _errorNodes.Add(coordinate);
    public void ResetErrors() => _errorNodes.Clear();

    public void SwitchCoordinatesStatus(IEnumerable<Coordinate> coordinates)
    {
        foreach (var coordinate in coordinates) SwitchCoordinateStatus(coordinate);
    }

    public void SwitchCoordinateStatus(Coordinate coordinate)
    {
        if (Nodes.Contains(coordinate)) Nodes.Remove(coordinate);
        else Nodes.Add(coordinate);
    }

    public void SetStartCoordinate(Coordinate coordinate)
    {
        _startNode = coordinate;
        if (Nodes.Contains(coordinate)) Nodes.Remove(coordinate);
        Nodes.Insert(0, coordinate);
    }

    public void SetEndCoordinate(Coordinate coordinate)
    {
        _endNode = coordinate;
        if (Nodes.Contains(coordinate)) Nodes.Remove(coordinate);
        Nodes.Add(coordinate);
    }

    public void SetDefaultStartCoordinate()
    {
        _startNode = Nodes.MinBy(c => c);
        Nodes.Remove(_startNode!);
        Nodes.Insert(0, _startNode!);
    }

    public void SetDefaultEndCoordinate()
    {
        _endNode = Nodes.MaxBy(c => c);
        Nodes.Remove(_endNode!);
        Nodes.Add(_endNode!);
    }

    public ITree<Coordinate> GenerateTreeOld()
    {
        if (_startNode is null) throw new ArgumentException("Start not defined");
        if (_endNode is null) throw new ArgumentException("End not defined");
        SetEndCoordinate(Nodes.Last());
        var tree = new TwoWayTree<Coordinate>();
        var segment = tree.LinkFrom(_startNode, 0);
        foreach (var coordinate in Nodes)
        {
            if (coordinate != _startNode) segment = segment.Next(coordinate);
            var firstCoordinateRightActivated = FirstRightCoordinate(coordinate);
            if (firstCoordinateRightActivated != coordinate)
            {
                var rightCoordinateNumber = Nodes.FindIndex(c => c == firstCoordinateRightActivated);
            }
            var firstCoordinateBottomActivated = FirstBottomCoordinate(coordinate);
            if (firstCoordinateBottomActivated != coordinate)
            {
                var bottomCoordinateNumber = Nodes.FindIndex(c => c == firstCoordinateBottomActivated);
            }
        }
        return tree;
    }

    public ITree<Coordinate> GenerateTree()
    {
        if (_startNode is null) throw new ArgumentException("Start not defined");
        if (_endNode is null) throw new ArgumentException("End not defined");
        SetEndCoordinate(Nodes.Last());
        var tree = new TwoWayTree<Coordinate>();
        var segment = tree.LinkFrom(_startNode);
        foreach (var coordinate in Nodes)
        {
            if (coordinate != _startNode) segment = segment.Next(coordinate);
            var firstCoordinateRightActivated = FirstRightCoordinate(coordinate);
            if (firstCoordinateRightActivated != coordinate)
            {
                var rightCoordinateNumber = Nodes.FindIndex(c => c == firstCoordinateRightActivated);
                segment.To(firstCoordinateRightActivated);
            }
            var firstCoordinateBottomActivated = FirstBottomCoordinate(coordinate);
            if (firstCoordinateBottomActivated != coordinate)
            {
                var bottomCoordinateNumber = Nodes.FindIndex(c => c == firstCoordinateBottomActivated);
                segment.To(firstCoordinateBottomActivated);
            }
        }
        return tree;
    }

    public override string ToString() => $"{Nodes.Count} nodes";

    private Coordinate FirstRightCoordinate(Coordinate coordinate) => Nodes.Where(c => c.Y == coordinate.Y && c.X > coordinate.X).MinBy(c => c.X) ?? coordinate;

    private Coordinate FirstBottomCoordinate(Coordinate coordinate) => Nodes.Where(c => c.X == coordinate.X && c.Y > coordinate.Y).MinBy(c => c.Y) ?? coordinate;

}
