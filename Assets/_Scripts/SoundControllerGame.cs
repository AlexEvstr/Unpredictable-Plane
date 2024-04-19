using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerGame : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _pickGemSound;
    [SerializeField] private AudioClip _plane;
    [SerializeField] private AudioClip _salutSound;
    [SerializeField] private AudioClip _winSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickButtonSound()
    {
        audioSource.PlayOneShot(_clickSound);
    }

    public void ExplosionSound()
    {
        audioSource.PlayOneShot(_explosionSound);
    }

    public void GameOverSound()
    {
        audioSource.PlayOneShot(_gameOverSound);
    }

    public void PickGemSound()
    {
        audioSource.PlayOneShot(_pickGemSound);
    }

    public void PlaneSoundOn()
    {
        audioSource.PlayOneShot(_plane);
    }

    public void PlaneSoundOff()
    {
        audioSource.Stop();
    }

    public void SalutSound()
    {
        audioSource.PlayOneShot(_salutSound);
    }

    public void WinSound()
    {
        audioSource.PlayOneShot(_winSound);
    }
}