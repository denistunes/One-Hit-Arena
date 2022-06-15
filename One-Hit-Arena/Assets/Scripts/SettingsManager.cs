using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public void SetMusicVolume (float volume)
    {
        AudioMixer.SetFloat("Music", volume);
    }

    public void SetSoundVolume (float volume)
    {
        AudioMixer.SetFloat("Sound", volume);
    }
}
