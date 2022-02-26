using LaserBrainTwister.Domain;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace LaserBrainTwister.Tests;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Node node = Node.New(1);
        node.Number.ShouldBe(1);
        Node.AllNodes.ShouldHaveSingleItem();
        Node.AllNodes[0].Number.ShouldBe(1);
    }

    [Fact]
    public void Test2()
    {
        Node node = Node.New(1);
        node.AddLinkedNode(2);
        node.LinkedNodeNumbers.ShouldBe(new List<int> { 2 });
        Node.AllNodes.Count.ShouldBe(2);
    }

    [Fact]
    public void Test3AddMoreLinkedNodes()
    {
        Node node = Node.New(1);
        node.AddLinkedNode(2);
        node.AddLinkedNode(3);
        node.LinkedNodeNumbers.ShouldBe(new List<int> { 2, 3 });
        Node.AllNodes.Count.ShouldBe(3);
    }
}