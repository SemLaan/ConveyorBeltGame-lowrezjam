using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileType
{

    empty,
    wall,
    conveyorLeft,
    conveyorRight,
    conveyorUp,
    conveyorDown,
    conveyorTurnLeft,
    conveyorTurnRight,
}


public class TileGrid : MonoBehaviour
{

    [SerializeField] private TileType[,] tilegrid = new TileType[15, 15];
    [SerializeField] private TileType tileBrush = TileType.empty;

    [SerializeField] private Vector2Int levelSize;

    [Header("Tile objects")]
    [SerializeField] private GameObject empty = null;
    [SerializeField] private GameObject wall = null,
                                        conveyorLeft = null, conveyorRight = null, conveyorUp = null, conveyorDown = null,
                                        conveyorTurnLeft = null, conveyorTurnRight = null;

    private Dictionary<TileType, GameObject> tileDict = null;
    


    private void Awake()
    {

        tileDict = new Dictionary<TileType, GameObject>()
        {
            {TileType.empty, empty},
            {TileType.wall, wall},
            {TileType.conveyorLeft, conveyorLeft},
            {TileType.conveyorRight, conveyorRight},
            {TileType.conveyorUp, conveyorUp},
            {TileType.conveyorDown, conveyorDown},
            {TileType.conveyorTurnLeft, conveyorTurnLeft},
            {TileType.conveyorTurnRight, conveyorTurnRight},
        };
    }
}
