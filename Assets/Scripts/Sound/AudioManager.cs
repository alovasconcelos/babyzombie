using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sound;
    public static AudioManager manager = null;

    void Awake()
    {
        if (manager == null)
        {   
            manager = this;
        }else if(manager != this) {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        sound.clip = clip;
        sound.Play();
    }
}
