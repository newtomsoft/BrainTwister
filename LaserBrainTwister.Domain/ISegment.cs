﻿namespace LaserBrainTwister.Domain;

public interface ISegment
{
    ISegment To(params int[] nodesNumber);
    ISegment Then(params int[] nodesNumber);
    ISegment NextTo(params int[] nodesNumber);
    ISegment Reverse();
}