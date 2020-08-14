using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileGridArray
{

    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private TileType[] values;

    public int Width { get { return width; } }

    public int Height { get { return height; } }

    public TileType this[int x, int y]
    {
        get { return values[y * width + x]; }
        set { values[y * width + x] = value; }
    }

    public TileGridArray(int width, int height)
    {
        this.width = width;
        this.height = height;

        values = new TileType[width * height];
    }
}