using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public static Dictionary<string, Item> itemDir = new Dictionary<string, Item>();
    public Sprite icon;
    public bool hasIcon;
    public string itemName;
    public string tooltext;
    public int id;

    public void Awake(){
        if(!itemDir.ContainsKey(itemName))
        {
        itemDir.Add(itemName,this);
        }
    }
}
