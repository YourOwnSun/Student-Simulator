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
    private bool activeTimer = false;

    private CardSlot cardSlot1;
    private CardSlot cardSlot2;
    private CardSlot cardSlot3;
    private CardSlot cardSlot4;
    private CardSlot cardSlot5;
    private CardSlot cardSlot6;
    private CardSlot outputCardSlot;
    private TMPro.TextMeshProUGUI timerText;


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
        outputCardSlot = transform.Find("OutputCardSlot").GetComponent<CardSlot>();
        timerText = transform.Find("TimerText").GetComponent<TMPro.TextMeshProUGUI>();

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
        outputCardSlot.OnCardDragged += OutputCardSlot_OnCardDragged;
    }

    private void OutputCardSlot_OnCardDragged(object sender, CardSlot.OnCardEventArgs e)
    {
        Debug.Log(outputCardSlot.transform.childCount);

        

        if (outputCardSlot.transform.childCount == 1) 
        {
            cardSlot1.transform.localScale = new Vector3(1, 1, 1);
            outputCardSlot.transform.GetChild(0).transform.SetParent(transform.parent);
            outputCardSlot.transform.localScale = new Vector3(0, 0, 0);
            descriptionText.text = defaultDescriptionText;
        }
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

        currentRecepie = null;

        nameText.text = defaultNameText;
        descriptionText.text = defaultDescriptionText;
        actionButton.GetComponent<Button>().interactable = false;

        int priority = -1;

        for (int i = 0; i < currentMainSlot.recepies.Count; ++i)
        {
            Debug.Log(currentMainSlot.recepies[i].actionName);
            Debug.Log(checkRecepie(currentMainSlot.recepies[i]));
            if (checkRecepie(currentMainSlot.recepies[i]) && currentMainSlot.recepies[i].priority > priority)
            {
                Debug.Log("recepie is correct");
                currentRecepie = currentMainSlot.recepies[i];
                priority = currentMainSlot.recepies[i].priority;
            }
        }

        if (currentRecepie != null)
        {
            Debug.Log("button");
            actionButton.GetComponent<Button>().interactable = true;
            nameText.text = currentRecepie.actionName;
            descriptionText.text = currentRecepie.actionDescription;
        }
    }

    private void CardSlot1_OnCardDragged(object sender, CardSlot.OnCardEventArgs e)
    {
        RemoveCard(0);

        CleanSlots();
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

        int allowedAspectFlag = 0;

        for(int i = 0; i < e.card.traitList.Count; ++i) 
        {
            for(int j = 0; j < currentMainSlot.conditions[0].allowedAspects.Count; ++j) 
            {
                if (e.card.traitList[i].aspect == currentMainSlot.conditions[0].allowedAspects[j]) 
                {
                    allowedAspectFlag += 1;
                }
            }
        }

        if(allowedAspectFlag == 0) 
        {
            cardSlot1.transform.GetChild(0).GetComponent<DragAndDropCard>().ReturnToStartingPosition();
            RemoveCard(0);
            return;
        }

        int priority = -1;

        for(int i = 0; i < currentMainSlot.recepies.Count; ++i) 
        {
            Debug.Log(currentMainSlot.recepies[i].actionName);
            Debug.Log(checkRecepie(currentMainSlot.recepies[i]));
            if (checkRecepie(currentMainSlot.recepies[i]) && currentMainSlot.recepies[i].priority > priority) 
            {
                Debug.Log("recepie is correct");
                currentRecepie = currentMainSlot.recepies[i];
                priority = currentMainSlot.recepies[i].priority;
            }
        }

        if (currentRecepie != null)
        {
            Debug.Log("button");
            actionButton.GetComponent<Button>().interactable = true;
            nameText.text = currentRecepie.actionName;
            descriptionText.text = currentRecepie.actionDescription;
        }

    }

    private void CardSlot1_OnCardDropped(object sender, CardSlot.OnCardEventArgs e)
    {
        AddCard(e.card, 0);

        int priority = -1;

        for (int i = 0; i < mainSlotRecepies.Count; ++i)
        {
            for (int j = 0; j < e.card.traitList.Count; ++j)
            {
                if (mainSlotRecepies[i].mainAspect == e.card.traitList[j].aspect && mainSlotRecepies[i].priority > priority)
                {
                    currentMainSlot = mainSlotRecepies[i];
                    priority = currentMainSlot.priority;
                }
            }
        }

        if (currentMainSlot == null)
        {
            cardSlot1.transform.GetChild(0).GetComponent<DragAndDropCard>().ReturnToStartingPosition();
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

        if (currentMainSlot.conditions.Count == 0)
        {
            Debug.Log(currentMainSlot.output.Count);

            if(currentMainSlot.output.Count != 0) 
            {
                Debug.Log("button");
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
        for (int j = 0; j < recepie.minimalRequirement.Count; ++j)
        {
            for (int k = 0; k < cardList[0].traitList.Count; ++k)
            {
                if (cardList[0].traitList[k].aspect == recepie.minimalRequirement[j].aspect)
                {
                    requirementsCheck[j].level -= cardList[0].traitList[k].level;
                }
            }
        }
        for (int i = 0; i < requirementsCheck.Count; ++i)
        {
            if (requirementsCheck[i].level > 0)
            {
                Debug.Log(requirementsCheck[i].aspect);
                Debug.Log(requirementsCheck[i].level);
                return false;
            }
        }
        return true;
    }

    public void ApplyRecepie() 
    {
        if(currentMainSlot == null) 
        {
            Debug.Log("Main slot is null on button press");
            return;
        }

        if(currentMainSlot.conditions.Count == 0) 
        {
            string tempText = currentMainSlot.outputDescription;
            float startingTIME = Timer.current.GetTime();

            cardSlot1.transform.localScale = new Vector3(0, 0, 0);
            cardSlot2.transform.localScale = new Vector3(0, 0, 0);

            //timerText.transform.localScale = new Vector3(1, 1, 1);

            //activeTimer = true;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if(currentMainSlot.expire == false) 
            {
                GameObject newCard = Instantiate(cardPrefab, outputCardSlot.transform.position, outputCardSlot.transform.rotation, outputCardSlot.transform);
                newCard.GetComponent<CardDisplay>().card = cardList[0];
                newCard.GetComponent<CardDisplay>().UpdateCard();
            }

            for(int i = 0; i < currentMainSlot.output.Count; ++i) 
            {
                GameObject newCard = Instantiate(cardPrefab, outputCardSlot.transform.position, outputCardSlot.transform.rotation, outputCardSlot.transform);
                newCard.GetComponent<CardDisplay>().card = currentMainSlot.output[i];
                newCard.GetComponent<CardDisplay>().UpdateCard();
            }
            

            Destroy(cardSlot1.transform.GetChild(0).gameObject);
            RemoveCard(0);
            CleanSlots();
            cardSlot1.transform.localScale = new Vector3(0, 0, 0);

            outputCardSlot.transform.localScale = new Vector3(1, 1, 1);

            descriptionText.text = tempText;

            actionButton.GetComponent<Button>().interactable = false;
            return;
        }

        if(currentRecepie != null) 
        {
            if (currentMainSlot.expire == false)
            {
                GameObject newCard = Instantiate(cardPrefab, outputCardSlot.transform.position, outputCardSlot.transform.rotation, outputCardSlot.transform);
                newCard.GetComponent<CardDisplay>().card = cardList[0];
                newCard.GetComponent<CardDisplay>().UpdateCard();
            }
            Destroy(cardSlot1.transform.GetChild(0).gameObject);
            RemoveCard(0);

            for (int i = 0; i < currentMainSlot.conditions.Count; ++i)
            {
                if (currentMainSlot.conditions[i].expire == false)
                {
                    GameObject newCard = Instantiate(cardPrefab, outputCardSlot.transform.position, outputCardSlot.transform.rotation, outputCardSlot.transform);
                    newCard.GetComponent<CardDisplay>().card = cardList[i + 1];
                    newCard.GetComponent<CardDisplay>().UpdateCard();
                }
                RemoveCard(i + 1);
            }

            if (cardSlot2.transform.childCount != 0)
            {
                Destroy(cardSlot2.transform.GetChild(0).gameObject);
            }
            if (cardSlot3.transform.childCount != 0)
            {
                Destroy(cardSlot3.transform.GetChild(0).gameObject);
            }
            if (cardSlot4.transform.childCount != 0)
            {
                Destroy(cardSlot4.transform.GetChild(0).gameObject);
            }
            if (cardSlot5.transform.childCount != 0)
            {
                Destroy(cardSlot5.transform.GetChild(0).gameObject);
            }
            if (cardSlot6.transform.childCount != 0)
            {
                Destroy(cardSlot6.transform.GetChild(0).gameObject);
            }

            string tempText = currentRecepie.outputDescription;

            for (int i = 0; i < currentRecepie.output.Count; ++i)
            {
                GameObject newCard = Instantiate(cardPrefab, outputCardSlot.transform.position, outputCardSlot.transform.rotation, outputCardSlot.transform);
                newCard.GetComponent<CardDisplay>().card = currentRecepie.output[i];
                newCard.GetComponent<CardDisplay>().UpdateCard();
            }


            timerText.transform.localScale = new Vector3(0, 0, 0);
            CleanSlots();

            descriptionText.text = tempText;

            cardSlot1.transform.localScale = new Vector3(0, 0, 0);

            outputCardSlot.transform.localScale = new Vector3(1, 1, 1);

            actionButton.GetComponent<Button>().interactable = false;
            return;
        }
        
    }


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

    public void CleanSlots() 
    {
        cardSlot2.transform.localScale = new Vector3(0, 0, 0);
        cardSlot3.transform.localScale = new Vector3(0, 0, 0);
        cardSlot4.transform.localScale = new Vector3(0, 0, 0);
        cardSlot5.transform.localScale = new Vector3(0, 0, 0);
        cardSlot6.transform.localScale = new Vector3(0, 0, 0);
        //............

        currentRecepie = null;
        currentMainSlot = null;

        nameText.text = defaultNameText;
        descriptionText.text = defaultDescriptionText;
        actionButton.GetComponent<Button>().interactable = false;
    }

    public Recepie GetCurrentRecepie() { return currentRecepie; }
    private Card GetCard(int slot) { return cardList[slot]; }

    private void SetCard(Card newCard, int slot) { cardList[slot] = newCard; }

    private void Update()
    {
        /*if (activeTimer) 
        {
            
        }*/
    }
};





