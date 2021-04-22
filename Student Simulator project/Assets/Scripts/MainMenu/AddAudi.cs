using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AddAudi : MonoBehaviour
{
    public AudioMixer mix;
    public void setVolume(float audi)
    {
        mix.SetFloat("audi", audi);
    }
}
