using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2 direction;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float halfSize = 0f;


    private void FixedUpdate()
    {

        Move(direction * speed * Time.deltaTime);
    }


    public void Move(Vector2 velocity)
    {
        
        if (velocity.x > 0)
        {

            float collisionDistance = CollisionCheck(Vector3.right);
            if (collisionDistance < velocity.x)
                velocity.x = collisionDistance;
        } else if (velocity.x < 0)
        {

            float collisionDistance = CollisionCheck(Vector3.left);
            if (collisionDistance < -velocity.x)
                velocity.x = -collisionDistance;
        }

        if (velocity.y > 0)
        {

            float collisionDistance = CollisionCheck(Vector3.up);
            if (collisionDistance < velocity.y)
                velocity.y = collisionDistance;
        } else if (velocity.y < 0)
        {

            float collisionDistance = CollisionCheck(Vector3.down);
            if (collisionDistance < -velocity.y)
                velocity.y = -collisionDistance;
        }

        transform.position = transform.position + (Vector3) velocity;
    }


    private float CollisionCheck(Vector3 direction)
    {

        Vector3 sideOfPlayer = transform.position + (direction * halfSize);

        Vector3 rayOrigin1, rayOrigin2;

        if (direction.x == 0)
        {

            rayOrigin1 = sideOfPlayer + Vector3.right * (halfSize - 0.01f);
            rayOrigin2 = sideOfPlayer + Vector3.left * (halfSize - 0.01f);
        } else // if direction.y == 0
        {

            rayOrigin1 = sideOfPlayer + Vector3.up * (halfSize - 0.01f);
            rayOrigin2 = sideOfPlayer + Vector3.down * (halfSize - 0.01f);
        }

        RaycastHit2D ray1 = Physics2D.Raycast(rayOrigin1, direction, 2, LayerMask.GetMask("Wall"));
        RaycastHit2D ray2 = Physics2D.Raycast(rayOrigin2, direction, 2, LayerMask.GetMask("Wall"));

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
