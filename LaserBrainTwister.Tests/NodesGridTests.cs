using System;
using System.Collections.Generic;
using System.Linq;

namespace LaserBrainTwister.Tests;

public class NodesGridTests
{
    [Fact]
    public void GridWithoutStartNode()
    {
        var grid = new NodesGrid();
        grid.SetEndCoordinate(new Coordinate(0, 0));
        var action = () => grid.GenerateTree();
        action.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void GridWithoutEndNode()
    {
        var grid = new NodesGrid();
        grid.SetStartCoordinate(new Coordinate(0, 0));
        var action = () => grid.GenerateTree();
        action.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void GridWithOnlyStartAndEndNode()
    {
        var grid = new NodesGrid();
        var startCoordinate = Coordinate.From(0, 0);
        var endCoordinate = Coordinate.From(1, 0);
        grid.SetStartCoordinate(startCoordinate);
        grid.SetEndCoordinate(endCoordinate);
        var tree = grid.GenerateTree();
        tree.Nodes.Count.ShouldBe(2);
        tree.Nodes[0].Number.ShouldBe(0);
        tree.Nodes[0].Item.ShouldBe(startCoordinate);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].Number.ShouldBe(1);
        tree.Nodes[1].Number.ShouldBe(1);
        tree.Nodes[1].Item.ShouldBe(endCoordinate);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[1].LinkedNodes[0].Number.ShouldBe(0);
    }

    [Fact]
    public void GridWith3Nodes()
    {
        var grid = new NodesGrid();
        var startCoordinate = Coordinate.From(0, 0);
        var coordinates = new List<Coordinate> { Coordinate.From(0, 10), };
        var endCoordinate = Coordinate.From(10, 10);
        grid.SwitchNodesStatus(coordinates);
        grid.SetStartCoordinate(startCoordinate);
        grid.SetEndCoordinate(endCoordinate);

        var tree = grid.GenerateTree();
        tree.Nodes.Count.ShouldBe(3);
        tree.Nodes[0].Number.ShouldBe(0);
        tree.Nodes[0].Item.ShouldBe(startCoordinate);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].Number.ShouldBe(1);
        tree.Nodes[1].Number.ShouldBe(1);
        tree.Nodes[1].Item.ShouldBe(coordinates[0]);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[1].LinkedNodes[0].Number.ShouldBe(0);
        tree.Nodes[1].LinkedNodes[1].Number.ShouldBe(2);
        tree.Nodes[2].Number.ShouldBe(2);
        tree.Nodes[2].Item.ShouldBe(endCoordinate);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[0].Number.ShouldBe(1);
    }

    [Fact]
    public void GridWith4Nodes()
    {
        var grid = new NodesGrid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0,  2),
            Coordinate.From(10,  2),
        };
        grid.SwitchNodesStatus(coordinates);
        grid.SetStartCoordinate(new Coordinate(0, 0));
        grid.SetEndCoordinate(new Coordinate(10, 10));

        var tree = grid.GenerateTree();
        tree.Nodes.Count.ShouldBe(4);
        tree.Nodes[0].Number.ShouldBe(0);
        tree.Nodes[0].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[0].LinkedNodes[0].Number.ShouldBe(1);
        tree.Nodes[1].Number.ShouldBe(1);
        tree.Nodes[1].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[1].LinkedNodes[0].Number.ShouldBe(0);
        tree.Nodes[1].LinkedNodes[1].Number.ShouldBe(2);
        tree.Nodes[2].Number.ShouldBe(2);
        tree.Nodes[2].LinkedNodes.Count.ShouldBe(2);
        tree.Nodes[2].LinkedNodes[0].Number.ShouldBe(1);
        tree.Nodes[2].LinkedNodes[1].Number.ShouldBe(3);
        tree.Nodes[3].Number.ShouldBe(3);
        tree.Nodes[3].LinkedNodes.Count.ShouldBe(1);
        tree.Nodes[3].LinkedNodes[0].Number.ShouldBe(2);
    }

    [Fact]
    public void GridWithComplexesNodes()
    {
        var grid = new NodesGrid();
        var coordinates = new List<Coordinate>
        {
            Coordinate.From(0, 0),
            Coordinate.From(4, 0),
            Coordinate.From(5, 0),
            Coordinate.From(7, 0),
            Coordinate.From(9, 0),
            Coordinate.From(12, 0),
            Coordinate.From(8, 1),
            Coordinate.From(12, 1),
            Coordinate.From(2, 2),
            Coordinate.From(6, 2),
            Coordinate.From(1, 3),
            Coordinate.From(3, 3),
            Coordinate.From(2, 4),
            Coordinate.From(7, 4),
            Coordinate.From(10, 4),
            Coordinate.From(12, 4),
            Coordinate.From(4, 5),
            Coordinate.From(6, 5),
            Coordinate.From(9, 5),
            Coordinate.From(12, 5),
            Coordinate.From(3, 6),
            Coordinate.From(8, 6),
            Coordinate.From(1, 7),
            Coordinate.From(5, 7),
            Coordinate.From(7, 7),
            Coordinate.From(10, 7),
            Coordinate.From(2, 8),
            Coordinate.From(9, 8),
            Coordinate.From(11, 8),
            Coordinate.From(12, 8),
            Coordinate.From(2, 9),
            Coordinate.From(3, 9),
            Coordinate.From(5, 9),
            Coordinate.From(7, 9),
            Coordinate.From(9, 9),
            Coordinate.From(12, 9),
            Coordinate.From(3, 10),
            Coordinate.From(5, 10),
            Coordinate.From(11, 11),
            Coordinate.From(13, 11),
        };
        grid.SwitchNodesStatus(coordinates);
        grid.SetStartCoordinate(new Coordinate(0, 0));
        grid.SetEndCoordinate(new Coordinate(13, 11));

        var tree = grid.GenerateTree();

        var expectedStringRoutesWithAllNodes = new List<string>
        {
            "(0,0) (4,0) (4,5) (6,5) (6,2) (2,2) (2,4) (7,4) (7,0) (5,0) (5,7) (1,7) (1,3) (3,3) (3,6) (8,6) (8,1) (12,1) (12,0) (9,0) (9,5) (12,5) (12,4) (10,4) (10,7) (7,7) (7,9) (5,9) (5,10) (3,10) (3,9) (2,9) (2,8) (9,8) (9,9) (12,9) (12,8) (11,8) (11,11) (13,11)",
            "(0,0) (4,0) (4,5) (6,5) (6,2) (2,2) (2,4) (2,8) (2,9) (3,9) (3,10) (5,10) (5,9) (7,9) (9,9) (12,9) (12,8) (12,5) (12,4) (10,4) (10,7) (7,7) (7,4) (7,0) (5,0) (5,7) (1,7) (1,3) (3,3) (3,6) (8,6) (8,1) (12,1) (12,0) (9,0) (9,5) (9,8) (11,8) (11,11) (13,11)",
        };

        foreach (var allNodesRouteFound in tree.GetRoutesFromStartToDeadEnds().Where(r => r.Nodes.Count == tree.Nodes.Count))
        {
            var found = expectedStringRoutesWithAllNodes.FirstOrDefault(str => str == allNodesRouteFound.ToString());
            found.ShouldNotBeNull();
            expectedStringRoutesWithAllNodes.Remove(allNodesRouteFound.ToString());
        }
        expectedStringRoutesWithAllNodes.Count.ShouldBe(0);
    }
}
