namespace LaserBrainTwister.Benchmark;

[MemoryDiagnoser, SuppressMessage("ReSharper", "MemberCanBePrivate.Global"), SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class GetRoutesBenchmark
{
    [Params(false, true)]
    public bool IsBruteForce { get; set; }

    [Benchmark]
    public List<Route<Coordinate>> GridWith21Nodes()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(2, 0), Coordinate.From(4, 0), Coordinate.From(7, 0), Coordinate.From(9, 0),
            Coordinate.From(1, 1), Coordinate.From(4, 1), Coordinate.From(6, 1), Coordinate.From(9, 1),
            Coordinate.From(1, 2), Coordinate.From(3, 2), Coordinate.From(9, 2),
            Coordinate.From(3, 3), Coordinate.From(4, 3),
            Coordinate.From(4, 5), Coordinate.From(7, 5), Coordinate.From(9, 5),
            Coordinate.From(4, 6), Coordinate.From(6, 6),
            Coordinate.From(4, 7), Coordinate.From(12, 7),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        return tree.GetRoutesFromStartToDeadEnds(IsBruteForce).ToList();
    }

    [Benchmark]
    public List<Route<Coordinate>> GridWit40Nodes()
    {
        var grid = new Grid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0), Coordinate.From(4, 0), Coordinate.From(5, 0), Coordinate.From(7, 0), Coordinate.From(9, 0), Coordinate.From(12, 0),
            Coordinate.From(8, 1), Coordinate.From(12, 1),
            Coordinate.From(2, 2), Coordinate.From(6, 2),
            Coordinate.From(1, 3), Coordinate.From(3, 3), Coordinate.From(2, 4),
            Coordinate.From(7, 4), Coordinate.From(10, 4), Coordinate.From(12, 4),
            Coordinate.From(4, 5), Coordinate.From(6, 5), Coordinate.From(9, 5), Coordinate.From(12, 5),
            Coordinate.From(3, 6), Coordinate.From(8, 6), Coordinate.From(1, 7),
            Coordinate.From(5, 7), Coordinate.From(7, 7), Coordinate.From(10, 7),
            Coordinate.From(2, 8), Coordinate.From(9, 8), Coordinate.From(11, 8), Coordinate.From(12, 8),
            Coordinate.From(2, 9), Coordinate.From(3, 9), Coordinate.From(5, 9), Coordinate.From(7, 9), Coordinate.From(9, 9), Coordinate.From(12, 9),
            Coordinate.From(3, 10), Coordinate.From(5, 10),
            Coordinate.From(11, 11), Coordinate.From(13, 11),
        };
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();

        var tree = grid.GenerateTree();
        return tree.GetRoutesFromStartToDeadEnds(IsBruteForce).ToList();
    }
}
