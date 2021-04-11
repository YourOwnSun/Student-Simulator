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
}

[System.Serializable]
public class Trait
{
    public Aspect aspect;
    public int level;

    public enum Aspect
    {
        Joker,
        Club,
        Heart,
        Diamond,
        Spade
    }
}
