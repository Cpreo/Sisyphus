using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler, IBeginDragHandler
{
    public bool craftingSlot;
    public bool containsItem;

    public Item this_item;
    public void OnDrop(PointerEventData eventData) {
        if(transform.childCount == 0){
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.parentAfterDrag = transform;
        Item drop_item = draggableItem.itemData;
        this_item = drop_item;
        // Remember to Add code for removing item, beginDrag
        if(craftingSlot){
            containsItem = true;
            AddItem(this_item);

        }
        }
    }

    public void OnBeginDrag(PointerEventData eventData){
        if(containsItem)
        {
            containsItem = false;
            RemoveItem(this_item);
            
        }
    }
    void AddItem(Item item) {
        if(transform.parent.tag == "Crafting Window"){
            //TODO: Support for multiple Crafting Windows, using an event system where the 
            // window subscribes to an add item event
            CraftingCombat crafting_window = transform.parent.GetComponent<CraftingCombat>();
            crafting_window.AddItem(item);
            
        }
    }

    void RemoveItem(Item item){
        CraftingCombat crafting_window = transform.parent.GetComponent<CraftingCombat>();
        crafting_window.RemoveItem(item);
        this_item = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
