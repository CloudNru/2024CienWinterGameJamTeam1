using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGame : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource soundEffect;
    public AudioClip addAudio;
    public AudioClip subtractAudio;
    public AudioClip bgm;
    public AudioClip successAudio;
    public AudioClip failAudio;
    int count;
    // Start is called before the first frame update

    private void Start()
    {
        backgroundMusic.Play();
        count = 0;
    }

    public void PlayAddSound()
    {
        if (count < 4) { 
            soundEffect.clip = addAudio;
            soundEffect.Play();
            count++;
        }
    }

    public void PlaySubtractSound()
    {
        soundEffect.clip = subtractAudio;
        soundEffect.Play();
        if (count > 0) { 
            count--;
        }
    }
    public void PlayGameOverSound()
    {
        //here will be condition fail or success
        soundEffect.clip = successAudio;
        soundEffect.Play();
    }


}
