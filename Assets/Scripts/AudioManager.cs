using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    float sfxVolume = 0.75f;

    [SerializeField] AudioSource music;
    [SerializeField] AudioClip pickupSFX;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeMusicVolume(float volume)
    {
        music.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxVolume = volume;
    }

    public void PlayPickupSFX()
    {
        GameObject player = FindObjectOfType<PlayerController>().gameObject;

        AudioSource.PlayClipAtPoint(pickupSFX,player.transform.position,sfxVolume);
    }
}
