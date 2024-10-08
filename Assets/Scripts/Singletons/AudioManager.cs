using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    [Header("Inscribed")]
    public List<AudioSource> HardcodedSFX = new List<AudioSource>();//predetermained sounds
    public AudioSource FlexibleSFX;//audio source for passing in audio clips
    public AudioSource Music;//Music
    // Start is called before the first frame update

    //play a preallocated sound
    public void PlaySound(int id)
    {
        Debug.Log("Playing a Sound");
        if (id < HardcodedSFX.Count)
            if(!HardcodedSFX[id].isPlaying || HardcodedSFX[id].time > 0.2f)
                HardcodedSFX[id].Play();
    }
    //play a sound clip passed through a function
    public void PlaySound(AudioClip sound)
    {
        Debug.Log("Playing a Sound");
        FlexibleSFX.clip = sound;
        FlexibleSFX.Play();
    }
}
