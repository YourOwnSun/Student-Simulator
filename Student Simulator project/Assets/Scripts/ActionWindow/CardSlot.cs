using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    private ActionSystem actionSystem;
    private Card card = null;

    public event EventHandler<OnCardEventArgs> OnCardDropped;
    public event EventHandler<OnCardEventArgs> OnCardDragged;
    public class OnCardEventArgs : EventArgs 
    {
        public Card card;
    }

    private void Start()
    {
        actionSystem = transform.parent.GetComponent<ActionSystem>();
    }

   
    public void OnDrop(PointerEventData eventData) 
    {
        if(eventData.pointerDrag != null && transform.childCount == 0) 
        {
            card = eventData.pointerDrag.GetComponent<CardDisplay>().card;
            OnCardDropped?.Invoke(this, new OnCardEventArgs { card = card }); 

            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.position = transform.position;                        
        }
    }

    public void CardDragged() 
    {
        if (transform.childCount == 1)
        {           
            OnCardDragged?.Invoke(this, new OnCardEventArgs { card = card });
            card = null;
            Debug.Log("Card Dragged Event");
        }
    }

    public Card GetCard() { return card; }

    public void SetCard(Card newCard) { card = newCard; }

    public ActionSystem GetActionSystem() { return actionSystem; }
}
