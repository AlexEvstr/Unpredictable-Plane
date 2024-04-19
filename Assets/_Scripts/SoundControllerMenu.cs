using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerMenu : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickButtonSound()
    {
        audioSource.PlayOneShot(_clickSound);
    }
}
