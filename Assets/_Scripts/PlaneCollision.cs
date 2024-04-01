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
            gameoverParticle.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Destroy(gameoverParticle, 3);

            Destroy(other.gameObject);
            DisactivatePlane();
        }
    }

    private void DisactivatePlane()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
    }
}
