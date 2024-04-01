using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverParticle;
    [SerializeField] private GameObject _starParticle;

    [SerializeField] private GameObject _gameoverPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade") || other.gameObject.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);

            GameObject gameoverParticle = Instantiate(_gameoverParticle);
            gameoverParticle.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Destroy(gameoverParticle, 3);

            StartCoroutine(ShowPanelGameOver());
            DisactivatePlane();
        }

        else if (other.gameObject.CompareTag("Star"))
        {
            GameObject starParticle = Instantiate(_starParticle);
            starParticle.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            Destroy(other.gameObject);
            Destroy(starParticle, 3);
        }
    }

    private void DisactivatePlane()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
    }

    private IEnumerator ShowPanelGameOver()
    {
        yield return new WaitForSeconds(3f);
        _gameoverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
