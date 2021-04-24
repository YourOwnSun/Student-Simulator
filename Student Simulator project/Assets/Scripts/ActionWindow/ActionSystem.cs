using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    private const int AMOUNT_OF_SLOTS = 6;
    private List<Card> cardList;

    private CardSlot cardSlot1;
    private CardSlot cardSlot2;
    private CardSlot cardSlot3;
    private CardSlot cardSlot4;
    private CardSlot cardSlot5;
    private CardSlot cardSlot6;

    private void Start()
    {
        cardList = new List<Card>();
        for (int i = 0; i < AMOUNT_OF_SLOTS; ++i) 
        {
            cardList.Add(null);
        }

        cardSlot1 = transform.Find("CardSlot1").GetComponent<CardSlot>();
        cardSlot2 = transform.Find("CardSlot2").GetComponent<CardSlot>();
        cardSlot3 = transform.Find("CardSlot3").GetComponent<CardSlot>();
        cardSlot4 = transform.Find("CardSlot4").GetComponent<CardSlot>();
        cardSlot5 = transform.Find("CardSlot5").GetComponent<CardSlot>();
        cardSlot6 = transform.Find("CardSlot6").GetComponent<CardSlot>();

        cardSlot1.OnCardDropped += CardSlot1_OnCardDropped;
        cardSlot2.OnCardDropped += CardSlot2_OnCardDropped;
        cardSlot3.OnCardDropped += CardSlot3_OnCardDropped;
        cardSlot4.OnCardDropped += CardSlot4_OnCardDropped;
        cardSlot5.OnCardDropped += CardSlot5_OnCardDropped;
        cardSlot6.OnCardDropped += CardSlot6_OnCardDropped;

        cardSlot1.OnCardDragged += CardSlot1_OnCardDragged;
        cardSlot2.OnCardDragged += CardSlot2_OnCardDragged;
        cardSlot3.OnCardDragged += CardSlot3_OnCardDragged;
        cardSlot4.OnCardDragged += CardSlot4_OnCardDragged;
        cardSlot5.OnCardDragged += CardSlot5_OnCardDragged;
        cardSlot6.OnCardDragged += CardSlot6_OnCardDragged;
    }

    private void CardSlot6_OnCardDragged(object sender, CardSlot.OnCardEventArgs e)
    {
        RemoveCard(5);
    }

    private void CardSlot5_OnCardDragged(object sender, CardSlot.OnCardEventArgs e)
    {
        RemoveCard(4);
    }

    private void CardSlot4_OnCardDragged(object sender, CardSlot.OnCardEventArgs e)
    {
        RemoveCard(3);
    }

    private void CardSlot3_OnCardDragged(object sender, CardSlot.OnCardEventArgs e)
    {
        RemoveCard(2);
    }

    private void CardSlot2_OnCardDragged(object sender, CardSlot.OnCardEventArgs e)
    {
        RemoveCard(1);
    }

    private void CardSlot1_OnCardDragged(object sender, CardSlot.OnCardEventArgs e)
    {
        RemoveCard(0);
        //............
    }

    private void CardSlot6_OnCardDropped(object sender, CardSlot.OnCardEventArgs e)
    {
        AddCard(e.card, 5);
    }

    private void CardSlot5_OnCardDropped(object sender, CardSlot.OnCardEventArgs e)
    {
        AddCard(e.card, 4);
    }

    private void CardSlot4_OnCardDropped(object sender, CardSlot.OnCardEventArgs e)
    {
        AddCard(e.card, 3);
    }

    private void CardSlot3_OnCardDropped(object sender, CardSlot.OnCardEventArgs e)
    {
        AddCard(e.card, 2);
    }

    private void CardSlot2_OnCardDropped(object sender, CardSlot.OnCardEventArgs e)
    {
        AddCard(e.card, 1);
    }

    private void CardSlot1_OnCardDropped(object sender, CardSlot.OnCardEventArgs e)
    {
        AddCard(e.card, 0);
        //.........
    }

    public bool ContainsCard(Card card)
    {
        for (int i = 0; i < AMOUNT_OF_SLOTS; ++i) 
        {
            if(cardList[i] != null && card.name == cardList[i].name) 
            {
                return true;
            }
        }
        return false;
    }

    public void AddCard(Card card, int slot) 
    {
        if(slot > -1 && slot < AMOUNT_OF_SLOTS && cardList[slot] == null) 
            cardList[slot] = card; 
        for(int i = 0; i < AMOUNT_OF_SLOTS; ++i) 
        {
            Debug.Log(cardList[i]);
            Debug.Log(i);
        }
    }

    public void RemoveCard(int slot) 
    {
        if (slot > -1 && slot < AMOUNT_OF_SLOTS && cardList[slot] != null)
            cardList[slot] = null;
        for (int i = 0; i < AMOUNT_OF_SLOTS; ++i)
        {
            Debug.Log(cardList[i]);
            Debug.Log(i);
        }
    }

    private Card GetCard(int slot) { return cardList[slot]; }

    private void SetCard(Card newCard, int slot) { cardList[slot] = newCard; }
}
