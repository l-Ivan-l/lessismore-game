using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource gameAudio;
    public List<AudioClip> audioClipsList = new List<AudioClip>();

    public void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }


    public void PlayButtonSound(float _volume)
    {
        gameAudio.PlayOneShot(audioClipsList[0], _volume);
    }

    public void PlayColorChangeSound(float _volume)
    {
        gameAudio.PlayOneShot(audioClipsList[1], _volume);
    }

    public void PlayDeathSound(float _volume)
    {
        gameAudio.PlayOneShot(audioClipsList[2], _volume);
    }

    public void PlayInitLandSound(float _volume)
    {
        gameAudio.PlayOneShot(audioClipsList[3], _volume);
    }

    public void PlayJumpSound(float _volume)
    {
        gameAudio.PlayOneShot(audioClipsList[4], _volume);
    }

    public void PlayLandSound(float _volume)
    {
        gameAudio.PlayOneShot(audioClipsList[5], _volume);
    }

    public void PlayTremorSound(float _volume)
    {
        gameAudio.PlayOneShot(audioClipsList[6], _volume);
    }
}
