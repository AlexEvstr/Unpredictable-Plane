using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSkin : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    private void Start()
    {
        int materialIndex = PlayerPrefs.GetInt("skinPlane", 0);
        gameObject.GetComponent<MeshRenderer>().material = _materials[materialIndex];
    }
}
