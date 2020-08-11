using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Vector3 direction;
    [SerializeField] public int speed;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 0;
        }
    }
}
