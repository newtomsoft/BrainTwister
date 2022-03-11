namespace LaserBrainTwister.Domain;

public record Coordinate(Abscissa X, Ordinate Y) : IComparable
{
    public static Coordinate From(int x, int y) => new((Abscissa)x, (Ordinate)y);

    public int CompareTo(object? obj) => obj is not Coordinate(var x, var y) ? 1 : X != x ? X.CompareTo(x) : Y.CompareTo(y);

    public override string ToString() => $"({X},{Y})";
}