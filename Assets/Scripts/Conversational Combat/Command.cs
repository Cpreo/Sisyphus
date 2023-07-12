using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Command : ScriptableObject
{
    public string CommandName;
    public List<Item> ingredients;
    public int choiceNum;
}
