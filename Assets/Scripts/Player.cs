using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2 direction;
    [SerializeField] private float speed;
    [SerializeField] private float halfSize;


    private void FixedUpdate()
    {

        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }


    private float CollisionCheck(Vector3 direction)
    {

        Vector3 sideOfPlayer = transform.position + (direction * halfSize);

        Vector3 rayOrigin1, rayOrigin2;

        if (direction.x == 0)
        {

            rayOrigin1 = sideOfPlayer + Vector3.right * halfSize;
            rayOrigin2 = sideOfPlayer + Vector3.left * halfSize;
        } else // if direction.y == 0
        {

            rayOrigin1 = sideOfPlayer + Vector3.up * halfSize;
            rayOrigin2 = sideOfPlayer + Vector3.down * halfSize;
        }

        RaycastHit2D ray1 = Physics2D.Raycast(rayOrigin1, direction, 2, 0 >> 8);
        RaycastHit2D ray2 = Physics2D.Raycast(rayOrigin2, direction, 2, 0 >> 8);

        if (ray1.collider != null && ray2.collider != null)
        {

            if (ray1.distance < ray2.distance)
                return ray1.distance;
            else
                return ray2.distance;
        } else if (ray1.collider != null)
        {

            return ray1.distance;
        } else if (ray2.collider != null)
        {

            return ray2.distance;
        } else
        {

            return float.PositiveInfinity;
        }
    }


    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.blue;

        Vector3 sideOfPlayer = transform.position + (Vector3.right * (halfSize + 0.25f));
        Gizmos.DrawLine(sideOfPlayer + Vector3.up * halfSize, sideOfPlayer + Vector3.down * halfSize);
    }
}
