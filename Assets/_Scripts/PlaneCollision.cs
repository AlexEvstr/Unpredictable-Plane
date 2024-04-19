using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverParticle;
    [SerializeField] private GameObject _starParticle;
    [SerializeField] private GameObject _winParticle;
    [SerializeField] private GameObject _lastStarParticle;

    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _smokeTrail;

    [SerializeField] private SoundControllerGame soundControllerGame;

    private void Start()
    {
        soundControllerGame.PlaneSoundOn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            soundControllerGame.PlaneSoundOff();
            soundControllerGame.ExplosionSound();
            Destroy(other.gameObject);
            if (GameButtons.Vibro == 1) Vibration.Vibrate();

            GameObject gameoverParticle = Instantiate(_gameoverParticle);
            gameoverParticle.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Destroy(gameoverParticle, 0.75f);

            StartCoroutine(ShowPanelGameOver());
            DisactivatePlane();
        }

        else if (other.gameObject.CompareTag("Star"))
        {
            StarsCount.countOfStars++;
            soundControllerGame.PickGemSound();


            if (StarsCount.countOfStars == 2)
            {
                if (GameButtons.Vibro == 1) Vibration.Vibrate();
                soundControllerGame.PlaneSoundOff();
                GameButtons.CurrentLevel++;
                PlayerPrefs.SetInt("currentLevel", GameButtons.CurrentLevel);

                if (GameButtons.CurrentLevel > GameButtons.MaxLevel)
                {
                    GameButtons.MaxLevel = GameButtons.CurrentLevel;
                    PlayerPrefs.SetInt("maxLevel", GameButtons.MaxLevel);
                }

                gameObject.GetComponent<MeshCollider>().enabled = false;

                GameObject lastStarParticle = Instantiate(_lastStarParticle);
                lastStarParticle.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                Destroy(lastStarParticle, 1.5f);

                StartCoroutine(ShowWinPanel());
            }
            else
            {
                if (GameButtons.Vibro == 1) Vibration.VibratePeek();
                GameObject starParticle = Instantiate(_starParticle);
                starParticle.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                Destroy(starParticle, 1f);
            }
            
            Destroy(other.gameObject);
            
        }
    }

    private void DisactivatePlane()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
        _smokeTrail.SetActive(false);
    }

    private IEnumerator ShowPanelGameOver()
    {
        yield return new WaitForSeconds(0.8f);
        _gameoverPanel.SetActive(true);
        soundControllerGame.GameOverSound();
        Time.timeScale = 0;
    }

    private IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(0.25f);
        if (GameButtons.Vibro == 1) Vibration.VibratePop();
        soundControllerGame.SalutSound();
        GameObject winParticle_1 = Instantiate(_winParticle);
        winParticle_1.transform.position = new Vector3(0, 7, 0);
        Destroy(winParticle_1, 1f);
        yield return new WaitForSeconds(0.1f);
        if (GameButtons.Vibro == 1) Vibration.VibratePop();
        soundControllerGame.SalutSound();
        GameObject winParticle_2 = Instantiate(_winParticle);
        winParticle_2.transform.position = new Vector3(-8, 7, 0);
        Destroy(winParticle_2, 1f);
        yield return new WaitForSeconds(0.1f);
        if (GameButtons.Vibro == 1) Vibration.VibratePop();
        soundControllerGame.SalutSound();
        GameObject winParticle_3 = Instantiate(_winParticle);
        winParticle_3.transform.position = new Vector3(8, 7, 0);
        Destroy(winParticle_3, 1f);
        yield return new WaitForSeconds(0.25f);
        if (GameButtons.Vibro == 1) Vibration.VibratePop();
        soundControllerGame.SalutSound();
        GameObject winParticle_4 = Instantiate(_winParticle);
        winParticle_4.transform.position = new Vector3(-4, 7, 0);
        Destroy(winParticle_4, 1f);
        yield return new WaitForSeconds(0.25f);
        if (GameButtons.Vibro == 1) Vibration.VibratePop();
        soundControllerGame.SalutSound();
        GameObject winParticle_5 = Instantiate(_winParticle);
        winParticle_5.transform.position = new Vector3(4, 7, 0);
        Destroy(winParticle_5, 1f);

        yield return new WaitForSeconds(1f);
        _winPanel.SetActive(true);
        soundControllerGame.WinSound();
        Time.timeScale = 0;
    }
}
