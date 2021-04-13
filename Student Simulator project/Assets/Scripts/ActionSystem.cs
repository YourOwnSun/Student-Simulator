using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem
{
    private const int AMOUNT_OF_SLOTS = 6;
    private List<Card> cardList = new List<Card>(AMOUNT_OF_SLOTS);
    
    public ActionSystem() 
    {

    }

    private bool IsEmpty(int slot) { return cardList[slot] == null; }

    private Card GetCard(int slot) { return cardList[slot]; }

    private void SetCard(Card newCard, int slot) { cardList[slot] = newCard; }
}
