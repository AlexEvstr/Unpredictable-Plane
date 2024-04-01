using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _star;

    private void Start()
    {
        StartCoroutine(SpawnBonus());
    }

    private IEnumerator SpawnBonus()
    {
        while (true)
        {
            int randomxPosition = Random.Range(-12, 12);
            GameObject newBonus = Instantiate(_star);
            newBonus.transform.position = new Vector3(randomxPosition, 0, 60);
            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }
}
