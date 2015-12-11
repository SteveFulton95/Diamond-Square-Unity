using System;

public abstract class AbstractBiome
{

    public DiamondSquare GenerateBiome(int size, float min, float max)
    {
        double dimension = Math.Pow(2.0, size) + 1;
        DiamondSquare ds = new DiamondSquare(Convert.ToInt32(dimension), min, max);
        return ds;
    }
}
