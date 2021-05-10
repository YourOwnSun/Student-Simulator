using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New main slot", menuName = "Main Slot")]
public class MainSlot : ScriptableObject
{
    public Aspect mainAspect;
    public string specificMainCard;
    public int priority;

    public string actionName;
    public string actionDescription;
    public string outputDescription;

    public List<Condition> conditions;

    public List<Recepie> recepies;

    public List<Card> output;
}

[System.Serializable]
public class  Condition
{
    public List<Aspect> allowedAspects;

    public string slotName = "";

    public bool expire = false;
}

[System.Serializable]
public class Recepie 
{
    public List<Trait> minimalRequirement;

    public List<string> specificCards;

    public int priority;

    public string actionName;
    public string actionDescription;
    public string outputDescription;

    public List<Card> output;
}