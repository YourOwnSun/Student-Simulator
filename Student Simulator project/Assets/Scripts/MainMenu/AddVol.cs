using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AddVol : MonoBehaviour
{
    public AudioMixer mix;
    public void setVolume(float vol)
    {
        mix.SetFloat("vol", vol);
    }
}

