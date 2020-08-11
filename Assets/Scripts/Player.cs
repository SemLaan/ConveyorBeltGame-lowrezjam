using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public Vector2 direction;
    [SerializeField] public float speed;


    private void FixedUpdate()
    {

        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
}
