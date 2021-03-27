using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TouchBut : MonoBehaviour
{
    public AudioSource audi;
    void Update()
    {
        audi.Play();
    }
}
