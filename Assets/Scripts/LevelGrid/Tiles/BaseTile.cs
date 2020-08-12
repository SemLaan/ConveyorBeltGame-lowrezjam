using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTile : MonoBehaviour
{

    public abstract void TileAction(int fixedUpdateCount, Player player, float downtime);
    
}
