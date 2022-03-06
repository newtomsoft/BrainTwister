using BenchmarkDotNet.Attributes;
using LaserBrainTwister.Domain.Route;
using LaserBrainTwister.Domain.Tree;

namespace LaserBrainTwister.Benchmark;

[MemoryDiagnoser]
public class GetRoutesBenchmark
{
    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822", Justification = "Benchmark don't support static methods")]
    public List<Route> GetRoutesUsingYieldReturn()
    {
        var tree = new Tree();
        tree.LinkFromOriginTo(1)
            .NextTo(0, 2, 16)
            .NextTo(1, 3, 23)
            .NextTo(2, 4, 13)
            .NextTo(3, 5, 18)
            .NextTo(4, 7)
            .NextTo(7, 21)
            .NextTo(6, 5, 15)
            .NextTo(9, 12)
            .NextTo(8, 17)
            .NextTo(11, 22)
            .NextTo(10, 20)
            .NextTo(8, 13, 26)
            .NextTo(12, 3, 14, 21)
            .NextTo(13, 15, 25)
            .NextTo(14, 7, 19)
            .NextTo(1, 17)
            .NextTo(16, 9, 18)
            .NextTo(17, 4, 19, 27)
            .NextTo(18, 15, 29)
            .NextTo(11, 21, 31)
            .NextTo(20, 6)
            .NextTo(10, 23)
            .NextTo(22, 2, 24, 32)
            .NextTo(23, 13, 25, 33)
            .NextTo(24, 14, 28)
            .NextTo(12, 27, 30)
            .NextTo(26, 18, 28, 34)
            .NextTo(27, 25, 29, 36)
            .NextTo(28, 19)
            .NextTo(26, 31)
            .NextTo(30, 32, 37)
            .NextTo(31, 23, 33, 38)
            .NextTo(32, 24, 34)
            .NextTo(33, 27, 35)
            .NextTo(34, 29)
            .NextTo(28, 39)
            .NextTo(31, 38)
            .NextTo(37, 32);
        return tree.GetRoutesFromStartToDeadEnds().ToList();
    }
}
