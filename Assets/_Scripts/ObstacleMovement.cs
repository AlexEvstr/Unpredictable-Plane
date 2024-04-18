using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float _obstacleSpeed = 25.0f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _obstacleSpeed);
    }
}