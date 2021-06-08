using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite art;

    public List<Trait> traitList;

    public CardTimer cardTimer;
}

[System.Serializable]
public class Trait
{
    public Aspect aspect;
    public int level;
}

[System.Serializable]
public class CardTimer 
{
    public Card outputCard;
    public float time;
}

public enum Aspect
{
    Joker,
    Club,
    Heart,
    Diamond,
    Spade,
    Book,
    Place,
    Ability,
    Funds,
    Person,
    Acquaintance,
    Job,
    Class,
    Goal,
    Ingredient
}
