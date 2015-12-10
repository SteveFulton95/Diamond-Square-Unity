using UnityEngine;
using System.Collections;

public class GenerateBiomes : MonoBehaviour {

    private Flatlands _fl;

    public void Start()
    {
        DiamondSquare b;
        int size = 10;
        _fl = new Flatlands();

        b = _fl.GenerateBiome(size, Flatlands._MinElevation, Flatlands._MaxElevation);

        for (int i = 0; i < b.Dimension; i++)
        {
            for(int j = 0; j < b.Dimension; j++)
            {
                Debug.Log("i: " + i + "j: " + j + "      " + b.Data[i, j]);
            }
        }
    }
}
