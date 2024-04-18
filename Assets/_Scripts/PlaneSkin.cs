using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSkin : MonoBehaviour
{
    [SerializeField] private GameObject[] _planes;

    private void Start()
    {
        int planeIndex = PlayerPrefs.GetInt("skinPlane", 0);
        _planes[planeIndex].SetActive(true);
    }
}
