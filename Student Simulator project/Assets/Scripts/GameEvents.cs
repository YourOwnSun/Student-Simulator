using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public event EventHandler<OnMouse1PressedEventArgs> OnMouse1Pressed;

    public event EventHandler<OnEndingEventArgs> OnEnding;

    public class OnMouse1PressedEventArgs : EventArgs
    {
        public string name;
        public string description;
        public Sprite art;
    }

    public class OnEndingEventArgs : EventArgs 
    {
        public int projectLvl;
        public int socialLvl;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        current = this;
    }

    public void WindowTriggerEvent(string cardName, string cardDescription, Sprite cardArt) 
    {
        if (OnMouse1Pressed != null) 
        {
            OnMouse1Pressed?.Invoke(this, new OnMouse1PressedEventArgs { name = cardName, description = cardDescription, art = cardArt });         
        }
    }

    public void EndingTriggerEvent(int project, int social)
    {
        if (OnEnding != null)
        {
            OnEnding?.Invoke(this, new OnEndingEventArgs { projectLvl = project, socialLvl = social});
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
