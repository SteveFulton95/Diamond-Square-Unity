using UnityEngine;
using System;

public class DiamondSquare 
{
    private int[,] _Data;
    private int _Dimension;
    private DiamondSquare _TL, _TR, _BL, _BR;

    public DiamondSquare(int d)
    {
        _Dimension = d;
        _Data = new int[_Dimension, _Dimension];

        InitializeCorners();

        if (_Dimension >= 3)
        {
            DiamondStep();
            SquareStep();
            SmashTogether();
        }

    }

    private DiamondSquare(int d, int[,] arr)
    {
        _Dimension = d;
        _Data = arr;

        if (_Dimension >= 3)
        {
            DiamondStep();
            SquareStep();
            SmashTogether();
        }
    }

    private void InitializeCorners()
    {
        int dim = _Dimension - 1;
        _Data[0, 0] = 10;
        _Data[dim, 0] = 10;
        _Data[0, dim] = 10;
        _Data[dim, dim] = 10;
    }

    private void DiamondStep()
    {
        // put a value in the middle of the square
        int pos = (_Dimension) / 2;
        _Data[pos, pos] = 2;
    }

    private void SquareStep()
    {
        int pos = (_Dimension) / 2;

        // make new squares
        _Data[0, pos] = 1;
        _Data[pos, 0] = 1;
        _Data[pos, _Dimension-1] = 1;
        _Data[_Dimension-1, pos] = 1;

        if (_Dimension >= 3)
        {
            int[,] data = new int[pos, pos];
            
            // Make the new sub-squares
            data = DuplicateTopLeft();
            _TL = new DiamondSquare(pos+1, data);
            data = DuplicateTopRight();
            _TR = new DiamondSquare(pos+1, data);
            data = DuplicatedBottomLeft();
            _BL = new DiamondSquare(pos+1, data);
            data = DuplicateBottomRight();
            _BR = new DiamondSquare(pos+1, data);
        }
    }

    private void SmashTogether()
    {
        int size = (_Dimension/2) + 1;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (!System.Object.Equals(_TL, null))
                {
                    _Data[i, j] = _TL.Data[i, j];
                    _Data[i, size + j - 1] = _TR.Data[i, j];
                    _Data[size + i - 1, j] = _BL.Data[i, j];
                    _Data[size + i - 1, size + j - 1] = _BR.Data[i, j];
                }  
            }
        }
    }

    private int[,] DuplicateTopLeft()
    {
        int newDimension = (_Dimension / 2) + 1;
        int[,] newData = new int[newDimension, newDimension];

        newData[0, 0] = _Data[0, 0];
        newData[0, newDimension - 1] = _Data[0, newDimension - 1];
        newData[newDimension - 1, 0] = _Data[newDimension - 1, 0];
        newData[newDimension - 1, newDimension - 1] = Data[newDimension - 1, newDimension - 1];

        return newData;
    }
    private int[,] DuplicateTopRight()
    {
        int newDimension = (_Dimension / 2) + 1;
        int[,] newData = new int[newDimension, newDimension];

        newData[0, 0] = _Data[0, newDimension-1];
        newData[0, newDimension - 1] = _Data[0, _Dimension - 1];
        newData[newDimension - 1, 0] = _Data[newDimension - 1, newDimension - 1];
        newData[newDimension - 1, newDimension - 1] = Data[newDimension - 1, _Dimension - 1];

        return newData;
    }
    private int[,] DuplicatedBottomLeft()
    {
        int newDimension = (_Dimension / 2) + 1;
        int[,] newData = new int[newDimension, newDimension];

        newData[0, 0] = _Data[newDimension - 1, 0];
        newData[0, newDimension - 1] = _Data[newDimension - 1, newDimension - 1];
        newData[newDimension - 1, 0] = _Data[_Dimension - 1, 0];
        newData[newDimension - 1, newDimension - 1] = Data[_Dimension - 1, newDimension - 1];

        return newData;
    }
    private int[,] DuplicateBottomRight()
    {
        int newDimension = (_Dimension / 2) + 1;
        int[,] newData = new int[newDimension, newDimension];

        newData[0, 0] = _Data[newDimension - 1, newDimension - 1];
        newData[0, newDimension - 1] = _Data[newDimension - 1, _Dimension - 1];
        newData[newDimension - 1, 0] = _Data[_Dimension - 1, newDimension - 1];
        newData[newDimension - 1, newDimension - 1] = Data[_Dimension - 1, _Dimension - 1];

        return newData;
    }

    // Properties
    public int[,] Data
    {
        get { return _Data; }
        set { _Data = value; }
    }
    public int Dimension
    {
        get { return _Dimension; }
        set { _Dimension = value; }
    }
}