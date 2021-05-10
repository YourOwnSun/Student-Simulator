using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionSystem : MonoBehaviour
{
    private const int AMOUNT_OF_SLOTS = 6;
    private List<Card> cardList;
    private MainSlot currentMainSlot = null;
    private Recepie currentRecepie = null;

    private CardSlot cardSlot1;
    private CardSlot cardSlot2;
    private CardSlot cardSlot3;
    private CardSlot cardSlot4;
    private CardSlot cardSlot5;
    private CardSlot cardSlot6;


    public List<MainSlot> mainSlotRecepies;
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI descriptionText;
    public GameObject actionButton;
    public GameObject cardPrefab;

    public string defaultNameText;
    public string defaultDescriptionText;


    private void Start()
    {
        cardList = new List<Card>();
        for (int i = 0; i < AMOUNT_OF_SLOTS; ++i)
        {
            cardList.Add(null);
        }

        nameText.text = defaultNameText;
        descriptionText.text = defaultDescriptionText;

        actionButton = transform.Find("ActionButton").gameObject;

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
        nameText.text = defaultNameText;
        descriptionText.text = defaultDescriptionText;
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

        int priority = -1;

        Debug.Log(1);
        for (int i = 0; i < mainSlotRecepies.Count; ++i)
        {
            Debug.Log(2);
            for (int j = 0; j < e.card.traitList.Count; ++j)
            {
                Debug.Log(3);
                Debug.Log(mainSlotRecepies[i].mainAspect);
                Debug.Log(e.card.traitList[j].aspect);
                if (mainSlotRecepies[i].mainAspect == e.card.traitList[j].aspect && mainSlotRecepies[i].priority > priority)
                {
                    Debug.Log(4);
                    currentMainSlot = mainSlotRecepies[i];
                    priority = currentMainSlot.priority;
                }
            }
        }

      

        
        if (currentMainSlot == null)
        {
            //cardSlot1.transform.GetChild(0).GetComponent<DragAndDropCard>().ReturnToStartingPosition();
            RemoveCard(0);
            Debug.Log("Current Main Slot == 0");
            return;
        }
        



        switch (currentMainSlot.conditions.Count)
        {
            case 1:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 2:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                cardSlot3.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 3:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                cardSlot3.transform.localScale = new Vector3(1, 1, 1);
                cardSlot4.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 4:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                cardSlot3.transform.localScale = new Vector3(1, 1, 1);
                cardSlot4.transform.localScale = new Vector3(1, 1, 1);
                cardSlot5.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 5:
                cardSlot2.transform.localScale = new Vector3(1, 1, 1);
                cardSlot3.transform.localScale = new Vector3(1, 1, 1);
                cardSlot4.transform.localScale = new Vector3(1, 1, 1);
                cardSlot5.transform.localScale = new Vector3(1, 1, 1);
                cardSlot6.transform.localScale = new Vector3(1, 1, 1);
                break;
            
        }
        nameText.text = currentMainSlot.actionName;
        descriptionText.text = currentMainSlot.actionDescription;

        if (currentMainSlot.conditions.Count == 1)
        {
            for (int i = 0; i < currentMainSlot.recepies.Count; ++i)
            {
                if (checkRecepie(currentMainSlot.recepies[i]) && (currentRecepie == null || currentRecepie.priority < currentMainSlot.recepies[i].priority)) 
                {
                    currentRecepie = currentMainSlot.recepies[i];
                }
            }

            if(currentRecepie != null) 
            {
                nameText.text = currentRecepie.actionName;
                descriptionText.text = currentRecepie.actionDescription;
                actionButton.GetComponent<Button>().interactable = true;
            }
        }
    }

    public bool checkRecepie(Recepie recepie)
    {
        List<Trait> requirementsCheck = new List<Trait>();
        foreach (var item in recepie.minimalRequirement)
        {
            requirementsCheck.Add(new Trait
            {
                aspect = item.aspect,
                level = item.level
            });
        }


        for (int i = 0; i < currentMainSlot.conditions.Count; ++i)
        {
            if (recepie.specificCards[i] != "" && (cardList[i + 1] == null || recepie.specificCards[i] != cardList[i + 1].name))
            {
                return false;
            }
            if (cardList[i + 1] != null) 
            {
                for (int j = 0; j < recepie.minimalRequirement.Count; ++j)
                {
                    for (int k = 0; k < cardList[i + 1].traitList.Count; ++k)
                    {
                        if (cardList[i + 1].traitList[k].aspect == recepie.minimalRequirement[j].aspect)
                        {
                            requirementsCheck[j].level -= cardList[i + 1].traitList[k].level;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < requirementsCheck.Count; ++i)
        {
            if (requirementsCheck[i].level > 0)
            {
                return false;
            }
        }
        return true;
    }
/*
    public void ApplyRecepie() 
    {
        for(int i = 0; i < currentMainSlot.conditions.Count; ++i) 
        {
            if(currentMainSlot.conditions[i].expire == false) 
            {
               GameObject newCard = Instantiate(cardPrefab, transform.position, transform.rotation, transform);
               newCard.GetComponent<CardDisplay>().card = cardList[i];
            }
            RemoveCard(i);
        }
        descriptionText.text = currentRecepie.outputDescription;
    }
*/

    public bool ContainsCard(Card card)
    {
        for (int i = 0; i < AMOUNT_OF_SLOTS; ++i)
        {
            if (cardList[i] != null && card.name == cardList[i].name)
            {
                return true;
            }
        }
        return false;
    }

    public void AddCard(Card card, int slot)
    {
        Debug.Log("Card added");
        if (slot > -1 && slot < AMOUNT_OF_SLOTS && cardList[slot] == null) 
        {
            cardList[slot] = card;
        }  
        for (int i = 0; i < AMOUNT_OF_SLOTS; ++i)
        {
            //Debug.Log(cardList[i]);
           // Debug.Log(i);
        }
    }

    public void RemoveCard(int slot)
    {
        Debug.Log("Card removed");
        if (slot > -1 && slot < AMOUNT_OF_SLOTS && cardList[slot] != null) 
        {
            cardList[slot] = null;
        }          
        for (int i = 0; i < AMOUNT_OF_SLOTS; ++i)
        {
            //Debug.Log(cardList[i]);
            //Debug.Log(i);
        }
    }

    public Recepie GetCurrentRecepie() { return currentRecepie; }
    private Card GetCard(int slot) { return cardList[slot]; }

    private void SetCard(Card newCard, int slot) { cardList[slot] = newCard; }
};





