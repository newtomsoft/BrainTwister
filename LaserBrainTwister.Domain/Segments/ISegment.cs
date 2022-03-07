﻿namespace LaserBrainTwister.Domain.Segments;

public interface ISegment
{
    ISegment To(params int[] nodesNumber);
    ISegment Then(params int[] nodesNumber);
    ISegment NextTo(params int[] nodesNumber);
    ISegment Next();
    ISegment Reverse();
}