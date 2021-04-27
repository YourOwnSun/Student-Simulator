using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    private const int AMOUNT_OF_SLOTS = 6;
    private List<Card> cardList;
    private MainSlot currentMainSlot = null;

    private CardSlot cardSlot1;
    private CardSlot cardSlot2;
    private CardSlot cardSlot3;
    private CardSlot cardSlot4;
    private CardSlot cardSlot5;
    private CardSlot cardSlot6;

    
    public List<MainSlot> mainSlotRecepies;


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
        cardSlot2.transform.localScale = new Vector3(0, 0, 0);
        cardSlot3.transform.localScale = new Vector3(0, 0, 0);
        cardSlot4.transform.localScale = new Vector3(0, 0, 0);
        cardSlot5.transform.localScale = new Vector3(0, 0, 0);
        cardSlot6.transform.localScale = new Vector3(0, 0, 0);
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
        


        for(int i = 0; i < mainSlotRecepies.Count && currentMainSlot == null; ++i) 
        {
            for(int j = 0; j < cardList[0].traitList.Count; ++j) 
            {
                if (mainSlotRecepies[i].mainAspect == cardList[0].traitList[j].aspect) 
                {
                    currentMainSlot = mainSlotRecepies[i];
                }
            }
        }

        if(currentMainSlot == null) 
        {
            cardSlot1.transform.GetChild(0).GetComponent<DragAndDropCard>().ReturnToStartingPosition();
            RemoveCard(0);
            return;
        }


        

        switch (currentMainSlot.conditions.Count)
        {
            case 2:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 3:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                cardSlot3.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 4:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                cardSlot3.transform.localScale = new Vector3(1, 1, 1);
                cardSlot4.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 5:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                cardSlot3.transform.localScale = new Vector3(1, 1, 1);
                cardSlot4.transform.localScale = new Vector3(1, 1, 1);
                cardSlot5.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 6:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                cardSlot3.transform.localScale = new Vector3(1, 1, 1);
                cardSlot4.transform.localScale = new Vector3(1, 1, 1);
                cardSlot5.transform.localScale = new Vector3(1, 1, 1);
                cardSlot6.transform.localScale = new Vector3(1, 1, 1);
                break;
            default:
                Debug.LogError("Switch case error");
                break;
        }
        
    }
    /*
    private bool CheckFirst(MainSlot recepie)
    {
        if (cardList[0].name == recepie.conditions[0].specificCard) 
        {
            return true;
        }

        bool traitConditionMet = false;

        for(int i = 0; i < cardList[0].traitList.Count; ++i) 
        {
            for(int j = 0; j < recepie.conditions[0].prohibitedAspects.Count; ++i) 
            {
                if (cardList[0].traitList[i].aspect == recepie.conditions[0].prohibitedAspects[j]) 
                {
                    return false;
                }
            }
        }

        return false;
    }

    private bool CheckAspects(MainSlot recepie) 
    {
        return false;
    }
    */

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
        }
    }

    public void RemoveCard(int slot) 
    {
        if (slot > -1 && slot < AMOUNT_OF_SLOTS && cardList[slot] != null)
            cardList[slot] = null;
        for (int i = 0; i < AMOUNT_OF_SLOTS; ++i)
        {
            Debug.Log(cardList[i]);
        }
    }

    private Card GetCard(int slot) { return cardList[slot]; }

    private void SetCard(Card newCard, int slot) { cardList[slot] = newCard; }
}
