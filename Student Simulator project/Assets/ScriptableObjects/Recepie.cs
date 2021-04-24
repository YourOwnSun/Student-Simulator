using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New recepie", menuName = "Recepie")]
public class Recepie : ScriptableObject
{
    public Trait initialTrait;
    public string initialName;

    public List<Trait> requiredTraits;
    public List<string> requiredNames;

    public List<Card> output;
}