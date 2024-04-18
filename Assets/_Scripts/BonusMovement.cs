using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    private float _bonusSpeed = 10.0f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _bonusSpeed);
    }
}
