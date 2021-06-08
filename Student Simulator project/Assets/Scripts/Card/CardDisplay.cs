using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardDisplay : MonoBehaviour, IPointerDownHandler
{
    public Card card;

    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI descriptionText;
    public Sprite artImage;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
    }

    public void UpdateCard() 
    {
        nameText.text = card.name;
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        Debug.Log("Pointer down");
        GameEvents.current.WindowTriggerEvent(card.name, card.description, card.art);
    }

}
