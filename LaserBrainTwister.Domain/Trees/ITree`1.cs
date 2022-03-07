﻿namespace LaserBrainTwister.Domain.Trees;

public interface ITree<T>
{
    List<Node<T>> Nodes { get; }
    ISegment<T> LinkFrom(T item, int fromNodeNumber);
    ISegment<T> LinkFromOriginTo(T item, int nodeNumber);
    IEnumerable<Route<T>> GetRoutesFromStartToDeadEnds(bool bruteForce = false);
    Route<T> GetLongestRoutesFromStartToDeadEnd();
    List<Route<T>> OptimizeRoutes();
}