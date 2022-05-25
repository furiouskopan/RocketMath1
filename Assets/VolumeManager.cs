using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioSource AudioSource;
    private float musicVolume = 1f;

    void Start()
    {
        AudioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
    }
    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
