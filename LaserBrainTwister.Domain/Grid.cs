namespace LaserBrainTwister.Domain;

public class Grid
{
    private readonly List<Coordinate> _enableNodes = new();
    private Coordinate? _startNode;
    private Coordinate? _endNode;

    public int GetEnableNodesNumber() => _enableNodes.Count;

    public bool IsEnable(Coordinate coordinate) => _enableNodes.Contains(coordinate);

    public void SwitchCoordinatesStatus(IEnumerable<Coordinate> coordinates)
    {
        foreach (var coordinate in coordinates) SwitchCoordinateStatus(coordinate);
    }

    public void SwitchCoordinateStatus(Coordinate coordinate)
    {
        if (_enableNodes.Contains(coordinate)) _enableNodes.Remove(coordinate);
        else _enableNodes.Add(coordinate);
    }

    public void SetStartCoordinate(Coordinate coordinate)
    {
        _startNode = coordinate;
        if (_enableNodes.Contains(coordinate)) _enableNodes.Remove(coordinate);
        _enableNodes.Insert(0, coordinate);
    }

    public void SetEndCoordinate(Coordinate coordinate)
    {
        _endNode = coordinate;
        if (_enableNodes.Contains(coordinate)) _enableNodes.Remove(coordinate);
        _enableNodes.Add(coordinate);
    }

    public void SetDefaultStartCoordinate()
    {
        _startNode = _enableNodes.MinBy(c => c);
        _enableNodes.Remove(_startNode!);
        _enableNodes.Insert(0, _startNode!);
    }

    public void SetDefaultEndCoordinate()
    {
        _endNode = _enableNodes.MaxBy(c => c);
        _enableNodes.Remove(_endNode!);
        _enableNodes.Add(_endNode!);
    }

    public ITree<Coordinate> GenerateTree()
    {
        if (_startNode is null || _endNode is null) throw new ArgumentException("start or end not defined");
        SetEndCoordinate(_enableNodes.Last());
        var tree = new TwoWayTree<Coordinate>();
        var segment = tree.LinkFrom(_startNode, 0);
        foreach (var coordinate in _enableNodes)
        {
            if (coordinate != _startNode) segment = segment.Next(coordinate);
            var firstCoordinateRightActivated = FirstRightCoordinate(coordinate);
            if (firstCoordinateRightActivated != coordinate)
            {
                var rightCoordinateNumber = _enableNodes.FindIndex(c => c == firstCoordinateRightActivated);
                segment.To(firstCoordinateRightActivated, rightCoordinateNumber);
            }
            var firstCoordinateBottomActivated = FirstBottomCoordinate(coordinate);
            if (firstCoordinateBottomActivated != coordinate)
            {
                var bottomCoordinateNumber = _enableNodes.FindIndex(c => c == firstCoordinateBottomActivated);
                segment.To(firstCoordinateBottomActivated, bottomCoordinateNumber);
            }
        }
        return tree;
    }

    public override string ToString() => $"{_enableNodes.Count} coordinates";

    private Coordinate FirstRightCoordinate(Coordinate coordinate) => _enableNodes.Where(c => c.Y == coordinate.Y && c.X > coordinate.X).MinBy(c => c.X) ?? coordinate;

    private Coordinate FirstBottomCoordinate(Coordinate coordinate) => _enableNodes.Where(c => c.X == coordinate.X && c.Y > coordinate.Y).MinBy(c => c.Y) ?? coordinate;
}
