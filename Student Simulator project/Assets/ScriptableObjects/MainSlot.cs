using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New main slot", menuName = "Main Slot")]
public class MainSlot : ScriptableObject
{
    public Aspect mainAspect;
    public string actionName;
    public string actionDescription;

    public List<Condition> conditions;

    public List<Recepie> recepies;


}

[System.Serializable]
public class  Condition
{
    public List<Aspect> allowedAspects;
    public List<Aspect> prohibitedAspects;

    public string slotName = "";

    public bool expire = false;
}

[System.Serializable]
public class Recepie 
{
    public List<Trait> minimalRequirement;

    public List<string> specificCards;

    public int priority;

    public List<Card> output;
}