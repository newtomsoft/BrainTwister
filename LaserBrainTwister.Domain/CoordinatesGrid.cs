namespace LaserBrainTwister.Domain;

public class CoordinatesGrid
{
    public List<Coordinate> Coordinates { get; } = new();

    private readonly HashSet<Coordinate> _errorNodes = new();
    private Coordinate? _startNode;
    private Coordinate? _endNode;

    public int GetEnableNodesNumber() => Coordinates.Count;

    public bool IsEnable(Coordinate coordinate) => Coordinates.Contains(coordinate);
    public bool IsError(Coordinate coordinate) => _errorNodes.Contains(coordinate);
    public void SetError(Coordinate coordinate) => _errorNodes.Add(coordinate);
    public void ResetErrors() => _errorNodes.Clear();

    public void SwitchCoordinatesStatus(IEnumerable<Coordinate> coordinates)
    {
        foreach (var coordinate in coordinates) SwitchCoordinateStatus(coordinate);
    }

    public void SwitchCoordinateStatus(Coordinate coordinate)
    {
        if (Coordinates.Contains(coordinate)) Coordinates.Remove(coordinate);
        else Coordinates.Add(coordinate);
    }

    public ITree<Coordinate> GenerateTree()
    {
        if (Coordinates.Count < 2) throw new ArgumentException("Not enough coordinates defined");
        SetDefaultStartCoordinate();
        SetDefaultEndCoordinate();
        var tree = new TwoWayTree<Coordinate>();
        var segment = tree.LinkFrom(_startNode!);
        foreach (var coordinate in Coordinates)
        {
            if (coordinate != _startNode) segment = segment.Next(coordinate);
            var firstCoordinateRightActivated = FirstRightCoordinate(coordinate);
            if (firstCoordinateRightActivated != coordinate) segment.To(firstCoordinateRightActivated);
            var firstCoordinateBottomActivated = FirstBottomCoordinate(coordinate);
            if (firstCoordinateBottomActivated != coordinate) segment.To(firstCoordinateBottomActivated);
        }
        return tree;
    }

    public override string ToString()
    {
        if (Coordinates.Count == 0) return string.Empty;
        var stringBuilder = new StringBuilder();
        Coordinates.ForEach(n =>
        {
            stringBuilder.Append(n);
            stringBuilder.Append(' ');
        });
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        return stringBuilder.ToString();
    }

    private void SetDefaultStartCoordinate()
    {
        _startNode = Coordinates.MinBy(c => c);
        Coordinates.Remove(_startNode!);
        Coordinates.Insert(0, _startNode!);
    }

    private void SetDefaultEndCoordinate()
    {
        _endNode = Coordinates.MaxBy(c => c);
        Coordinates.Remove(_endNode!);
        Coordinates.Add(_endNode!);
    }

    private Coordinate FirstRightCoordinate(Coordinate coordinate) => Coordinates.Where(c => c.Y == coordinate.Y && c.X > coordinate.X).MinBy(c => c.X) ?? coordinate;

    private Coordinate FirstBottomCoordinate(Coordinate coordinate) => Coordinates.Where(c => c.X == coordinate.X && c.Y > coordinate.Y).MinBy(c => c.Y) ?? coordinate;

}
