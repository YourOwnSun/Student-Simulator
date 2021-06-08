using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer current;
    public bool paused = true;
    private float time;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        time = 0;
    }

    public float GetTime() { return time; }

    public void NormalSpeed() { speed = 1; }

    public void HalfSpeed() { speed = 0.5f; }

    public void TurboSpeed() { speed = 3; }

    public void FastestSpeed() { speed = 10; }

    public void PauseFunction() 
    {
        if(paused) 
        {
            paused = false;
            return;
        }
        paused = true;
    }

    private void FixedUpdate()
    {
        if (!paused)
        {
            time += Time.deltaTime * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
