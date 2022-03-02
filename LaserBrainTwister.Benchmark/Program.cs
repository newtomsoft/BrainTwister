using BenchmarkDotNet.Running;
using LaserBrainTwister.Benchmark;

var summary = BenchmarkRunner.Run<GetRoutesBenchmark>();