using System.Text.Json;

namespace LaserBrainTwister.UI.Blazor.Pages;

public partial class Laser : ComponentBase
{
    private const sbyte MaxRow = 15;
    private readonly CoordinatesGrid _nodesCoordinatesGrid = new();
    private bool _isSolved;
    public const string NodeEnabled = "btn-enabled";
    public const string NodeDisable = "btn-disable";
    public const string NodeError = "btn-error";

    private async Task OnClick(Coordinate coordinate)
    {
        await _js.InvokeAsync<string>("resetCanvas");
        _nodesCoordinatesGrid.SwitchCoordinateStatus(coordinate);
    }

    private async Task Solve()
    {
        _nodesCoordinatesGrid.ResetErrors();
        var tree = _nodesCoordinatesGrid.GenerateTree();
        var route = tree.GetRoutesWithAllNodes().FirstOrDefault() ?? tree.GetRouteWithMostNodes();
        if (route is null) return;
        _isSolved = route.NodesNumber() == _nodesCoordinatesGrid.GetEnableNodesNumber();
        if (!_isSolved)
        {
            var coordinatesInError = _nodesCoordinatesGrid.Coordinates.Except(route.Nodes.Select(n => n.Item)).ToList();
            coordinatesInError.ForEach(c => _nodesCoordinatesGrid.SetError(c));
        }
        await DrawLines(route);
    }

    private async Task DrawLines(Route<Coordinate> route)
    {
        var firstNode = route.Nodes.First();
        foreach (var node in route.Nodes.Where(n => n != firstNode))
        {
            var (firstX, firstY) = firstNode.Item;
            var (secondX, secondY) = node.Item;
            var firstElementId = $"btn{firstX}_{firstY}";
            var secondElementId = $"btn{secondX}_{secondY}";
            await DrawConnection(firstElementId, secondElementId);
            firstNode = node;
        }
    }

    private async ValueTask<string> DrawConnection(string firstElementId, string secondElementId)
    {
        return await _js.InvokeAsync<string>("connectElements", firstElementId, secondElementId, _isSolved);
    }

    private async Task Export()
    {
        if (_isSolved is not true) return;
        var json = JsonSerializer.Serialize(_nodesCoordinatesGrid.Coordinates);
        await _js.InvokeVoidAsync("BlazorDownloadFile", $"grid{DateTime.Now.ToFileTime()}.json", "application/octet-stream", json);
    }
}
