using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Vector3 direction;

    void Update()
    {
        transform.position += direction * Time.deltaTime;
    }
}
