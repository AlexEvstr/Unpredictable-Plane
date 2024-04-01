using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    private float _smooth = 10.0f;

    private void FixedUpdate()
    {
        Quaternion target = Quaternion.Euler(0, 0, Input.acceleration.x * -100);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * _smooth);
    }
}
