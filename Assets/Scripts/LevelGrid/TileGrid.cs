﻿using System.Collections;
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

    [Header("Tile collision detection")]
    [SerializeField] private Transform player = null;

    [Header("Tile object prefabs")]
    [SerializeField] private GameObject empty = null;
    [SerializeField] private GameObject wall = null,
                                        conveyorLeft = null, conveyorRight = null, conveyorUp = null, conveyorDown = null,
                                        conveyorTurnLeft = null, conveyorTurnRight = null;

    private Dictionary<TileType, GameObject> tileDict = null;
    private List<Transform> tiles = new List<Transform>();
    


    private void Awake()
    {


        // TEMPORARY test
        tilegrid[1, 1] = TileType.conveyorUp;
        tilegrid[1, 2] = TileType.conveyorUp;
        tilegrid[2, 1] = TileType.conveyorUp;
        tilegrid[2, 2] = TileType.conveyorUp;


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

        // initializing the tiles
        for (int x = 0; x < levelSize.x; x++)
            for (int y = 0; y < levelSize.y; y++)
            {

                GameObject tile = tileDict[tilegrid[x, y]];
                GameObject instantiatedTile = Instantiate(tile, new Vector3(x + 1, y + 1, 0), Quaternion.identity, transform);
                tiles.Add(instantiatedTile.transform);
            }
    }



    private void FixedUpdate()
    {

        float closestTileDistance = float.PositiveInfinity;
        Transform closestTile = null;

        foreach (Transform tile in tiles)
        {

            float distance = Vector2.Distance(tile.position, player.position);
            if (distance < closestTileDistance)
            {

                closestTileDistance = distance;
                closestTile = tile;
            }
        }

        BaseTile collisionTile = closestTile.GetComponent<BaseTile>();
        collisionTile.TileAction(0, player, Time.fixedDeltaTime);
    }
}
