using Microsoft.AspNetCore.Components;

namespace LaserBrainTwister.UI.Blazor.Pages;

public partial class Laser : ComponentBase
{
    private const sbyte MaxRow = 15;
    private readonly Grid _nodesGrid = new();
    public const string BtnEnabled = "btn-enabled";
    public const string BtnDisable = "btn-disable";

    private async Task OnClick(Coordinate coordinate)
    {
        await _js.InvokeAsync<string>("resetCanvas");
        _nodesGrid.SwitchCoordinateStatus(coordinate);
    }

    private async Task GenerateTwoWayTree()
    {
        _nodesGrid.SetDefaultStartCoordinate();
        _nodesGrid.SetDefaultEndCoordinate();
        var tree = _nodesGrid.GenerateTree();
        var route = tree.GetRoutesWithAllNodes().FirstOrDefault() ?? tree.GetLongestRoute();
        if (route is null) return;
        if (route.NodesNumber() == _nodesGrid.GetEnableNodesNumber()) 
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
        return await _js.InvokeAsync<string>("connectElements", firstElementId, secondElementId);
    }
}
