using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundTouchButton : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip onHover;
    public AudioClip onClick;
    public void HoverSound()
    {
        sound.PlayOneShot(onHover);
    }

    public void ClickSound()
    {
        sound.PlayOneShot(onClick);
    }

}
