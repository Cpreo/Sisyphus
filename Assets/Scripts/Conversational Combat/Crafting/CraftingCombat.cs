using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Crafting Combat - v0
v1
1. Obtains items slotted into the crafting section of the Ui
2. Sends information to PuzzleManager to add ingredient/ remove ingredients
Also has to communicate with the active puzzle's valid Items as well
v2
3. Upon Item drag in, Spawn in an inventory Slot if all of the ones are currently taken
3b. Remove inventory slot if not dragged in
4. Remove inventory slot if dragged out of crafting window

*/
public class CraftingCombat : MonoBehaviour
{
    public static List<GameObject> craftingSlots;
    // Add ingredient to puzzle using this line
    //PuzzleManager.GetInstance().activePuzzle.AddIngredient()
    // should probabally add a line of code in the display that adds/removes commands and 
    // also adds/removes crafting slots
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Updates the list of crafting slots
    void GetCraftingSlots(){
        craftingSlots.Clear();
        GameObject craftingItems = GameObject.Find("Crafting Items");
        foreach (Transform child in craftingItems.transform)
        {
            if (child.tag == "Inventory Slot")
            {
                craftingSlots.Add(child.gameObject);
            }
        }
    }
    public void AddItem(Item item) {

        Debug.Log(PuzzleManager.GetInstance().hi);
        PuzzleManager.GetInstance().GetPuzzle().AddIngredient(item);
        Debug.Log("Item Added!");
    }
    public void RemoveItem(Item item) {
        PuzzleManager.GetInstance().GetPuzzle().RemoveIngredient(item);
        Debug.Log("Item Removed!");
    }
}
