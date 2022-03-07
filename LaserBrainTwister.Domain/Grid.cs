﻿namespace LaserBrainTwister.Domain;

public class Grid
{
    private readonly List<Coordinate> _coordinates = new();
    private Coordinate? _startCoordinate;
    private Coordinate? _endCoordinate;

    public bool IsActivated(Coordinate coordinate) => _coordinates.Contains(coordinate);

    public void SwitchCoordinatesStatus(IEnumerable<Coordinate> coordinates)
    {
        foreach (var coordinate in coordinates) SwitchCoordinateStatus(coordinate);
    }

    public void SwitchCoordinateStatus(Coordinate coordinate)
    {
        if (_coordinates.Contains(coordinate)) _coordinates.Remove(coordinate);
        else _coordinates.Add(coordinate);
    }

    public void SetStartCoordinate(Coordinate coordinate)
    {
        _startCoordinate = coordinate;
        if (_coordinates.Contains(coordinate)) _coordinates.Remove(coordinate);
        _coordinates.Insert(0, coordinate);
    }

    public void SetEndCoordinate(Coordinate coordinate)
    {
        _endCoordinate = coordinate;
        if (_coordinates.Contains(coordinate)) _coordinates.Remove(coordinate);
        _coordinates.Add(coordinate);
    }

    public void SetDefaultStartCoordinate()
    {
        _startCoordinate = _coordinates.MinBy(c => c);
        _coordinates.Remove(_startCoordinate!);
        _coordinates.Insert(0, _startCoordinate!);
    }

    public void SetDefaultEndCoordinate()
    {
        _endCoordinate = _coordinates.MaxBy(c => c);
        _coordinates.Remove(_endCoordinate!);
        _coordinates.Add(_endCoordinate!);
    }

    public ITree<Coordinate> GenerateTree()
    {
        if (_startCoordinate is null || _endCoordinate is null) throw new ArgumentException("start or end not defined");
        SetEndCoordinate(_coordinates.Last());
        var tree = new TwoWayTree<Coordinate>();
        var segment = tree.LinkFrom(_startCoordinate, 0);
        foreach (var coordinate in _coordinates)
        {
            if (coordinate != _startCoordinate) segment = segment.Next(coordinate);
            var firstCoordinateRightActivated = FirstRightCoordinate(coordinate);
            if (firstCoordinateRightActivated != coordinate)
            {
                var rightCoordinateNumber = _coordinates.FindIndex(c => c == firstCoordinateRightActivated);
                segment.To(firstCoordinateRightActivated, rightCoordinateNumber);
            }
            var firstCoordinateBottomActivated = FirstBottomCoordinate(coordinate);
            if (firstCoordinateBottomActivated != coordinate)
            {
                var bottomCoordinateNumber = _coordinates.FindIndex(c => c == firstCoordinateBottomActivated);
                segment.To(firstCoordinateBottomActivated, bottomCoordinateNumber);
            }
        }
        return tree;
    }

    private Coordinate FirstRightCoordinate(Coordinate coordinate) => _coordinates.FirstOrDefault(c => c.Y == coordinate.Y && c.X > coordinate.X) ?? coordinate;

    private Coordinate FirstBottomCoordinate(Coordinate coordinate) => _coordinates.FirstOrDefault(c => c.X == coordinate.X && c.Y > coordinate.Y) ?? coordinate;
}