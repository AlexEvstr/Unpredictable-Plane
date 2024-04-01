using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int randomxPosition = Random.Range(-12, 12);
            int randomIndex = Random.Range(0, _obstacles.Length);
            GameObject newObstacle = Instantiate(_obstacles[randomIndex]);
            newObstacle.transform.position = new Vector3(randomxPosition, 0, 60);
            yield return new WaitForSeconds(2f);
        }
    }
}
