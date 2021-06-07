using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI descriptionText;
    public Image artImage;

    public event EventHandler OnMouse1Pressed;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
    }

    public void UpdateCard() 
    {
        nameText.text = card.name;
    }

    private void OnMouseDown()
    {
        
    }
}
