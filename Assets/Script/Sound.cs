using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Sound : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;
    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == 40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
    public void StopSound()
    {
        AudioListener.volume = 0;
    }  
    public void StartSound()
    {
        AudioListener.volume = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
