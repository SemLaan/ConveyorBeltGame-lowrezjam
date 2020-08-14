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

    [HideInInspector] public TileGridArray tilegrid = new TileGridArray(15, 15);
    [SerializeField] public TileType tileBrush = TileType.empty;

    public Vector2Int levelSize;

    [Header("Tile collision detection")]
    [SerializeField] private Player player = null;

    [Header("Tile object prefabs")]
    [SerializeField] private GameObject empty = null;
    [SerializeField] private GameObject wall = null,
                                        conveyorLeft = null, conveyorRight = null, conveyorUp = null, conveyorDown = null,
                                        conveyorTurnLeft = null, conveyorTurnRight = null;

    [HideInInspector] public bool pauseConveyorbelt = false;

    private Dictionary<TileType, GameObject> tileDict = null;
    private List<Transform> tiles = new List<Transform>();
    


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

        if(pauseConveyorbelt == false)
        {
            float closestTileDistance = float.PositiveInfinity;
            Transform closestTile = null;


            foreach (Transform tile in tiles)
            {

                float distance = Vector2.Distance(tile.position, player.transform.position);
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
}
