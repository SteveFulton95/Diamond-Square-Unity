using System;

public abstract class AbstractBiome {

    public DiamondSquare GenerateBiome(int size, int min, int max)
    {
        double dimension = Math.Pow(2.0, size) + 1;
        DiamondSquare ds = new DiamondSquare(Convert.ToInt32(dimension));
        return ds;
    }
}
