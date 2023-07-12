using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioClip attackAudio,treasureAudio,hurtAudio;
    
    private void Awake()
    {
        instance = this;
    }

    public void AttackAudio()
    {
        audioSource.clip = attackAudio;
        audioSource.Play();
    }

    public void TreasureAudio()
    {
        audioSource.clip = treasureAudio;
        audioSource.Play();
    }
    
    public void HurtAudio()
    {
        audioSource.clip = hurtAudio;
        audioSource.Play();
    }
}
