using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{

    up,
    down,
    left,
    right
}

public class ConveyorBelt : BaseTile
{

    [SerializeField] private Direction pushDirection = Direction.up;
    [SerializeField] private float pushSpeed = 1;

    public override void TileAction(int fixedUpdateCount, Player player, float downtime)
    {

        if (pushDirection == Direction.up)
            player.Move(downtime * pushSpeed * Vector3.up);
        else if (pushDirection == Direction.down)
            player.Move(downtime * pushSpeed * Vector3.down);
        else if (pushDirection == Direction.left)
            player.Move(downtime * pushSpeed * Vector3.left);
        else if (pushDirection == Direction.right)
            player.Move(downtime * pushSpeed * Vector3.right);
    }
}
