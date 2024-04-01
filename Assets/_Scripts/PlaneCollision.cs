using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade") || other.gameObject.CompareTag("Bomb"))
        {
            GameObject gameoverParticle = Instantiate(_gameoverParticle);
            Destroy(gameoverParticle, 3);
            DisactivatePlane();
        }
    }

    private void DisactivatePlane()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
    }
}
