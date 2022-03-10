namespace LaserBrainTwister.Benchmark;

[MemoryDiagnoser, SuppressMessage("ReSharper", "MemberCanBePrivate.Global"), SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global"), SuppressMessage("Performance", "CA1822:Marquer les membres comme étant static", Justification = "<En attente>")]
public class GetRoutesBenchmark
{
    [Benchmark]
    [Arguments(false)]
    [Arguments(true)]
    public List<Route<Coordinate>> GetRoutesFromStartToDeadEnds(bool bruteForce)
    {
        return Grid.GenerateTree().GetRoutes(bruteForce).ToList();
    }

    [ParamsSource(nameof(SetGrid))]
    public Grid Grid { get; set; } = new();

    public IEnumerable<Grid> SetGrid
    {
        get
        {
            var coordinates0 = new List<Coordinate>
            {
                Coordinate.From(0, 0), Coordinate.From(2, 0), Coordinate.From(4, 0), Coordinate.From(7, 0), Coordinate.From(9, 0),
                Coordinate.From(1, 1), Coordinate.From(4, 1), Coordinate.From(6, 1), Coordinate.From(9, 1),
                Coordinate.From(1, 2), Coordinate.From(3, 2), Coordinate.From(9, 2),
                Coordinate.From(3, 3), Coordinate.From(4, 3),
                Coordinate.From(4, 5), Coordinate.From(7, 5), Coordinate.From(9, 5),
                Coordinate.From(4, 6), Coordinate.From(6, 6),
                Coordinate.From(4, 7), Coordinate.From(12, 7),
            };
            //yield return GetGrid(coordinates0);

            var coordinates1 = new List<Coordinate>
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
            //yield return GetGrid(coordinates1);

            var coordinates2 = new List<Coordinate>
            {
                Coordinate.From(0, 0), Coordinate.From(4, 0), Coordinate.From(8, 0), Coordinate.From(13, 0),
                Coordinate.From(1, 1), Coordinate.From(3, 1), Coordinate.From(6, 1), Coordinate.From(8, 1), Coordinate.From(10, 1), Coordinate.From(12, 1),
                Coordinate.From(2, 2), Coordinate.From(5, 2), Coordinate.From(8, 2), Coordinate.From(10, 2), Coordinate.From(11, 2),
                Coordinate.From(3, 3), Coordinate.From(10, 3),
                Coordinate.From(0, 4), Coordinate.From(6, 4),
                Coordinate.From(2, 5), Coordinate.From(13, 5),
                Coordinate.From(2, 6), Coordinate.From(4, 6), Coordinate.From(7, 6), Coordinate.From(10, 6), Coordinate.From(12, 6), Coordinate.From(13, 6),
                Coordinate.From(0, 7), Coordinate.From(1, 7), Coordinate.From(5, 7), Coordinate.From(8, 7), Coordinate.From(9, 7), Coordinate.From(11, 7),
                Coordinate.From(0, 8), Coordinate.From(1, 8), Coordinate.From(2, 8), Coordinate.From(7, 8), Coordinate.From(11, 8), Coordinate.From(13, 8),
                Coordinate.From(1, 9), Coordinate.From(4, 9),
                Coordinate.From(0, 10), Coordinate.From(9, 10), Coordinate.From(11, 10), Coordinate.From(14, 10),
            };
            yield return GetGrid(coordinates2);
        }
    }

    private static Grid GetGrid(IEnumerable<Coordinate> coordinates)
    {
        var grid = new Grid();
        grid.SwitchCoordinatesStatus(coordinates);
        grid.SetDefaultStartCoordinate();
        grid.SetDefaultEndCoordinate();
        return grid;
    }
}
