using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(TooltipTrigger))] 
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Item itemData;
    [HideInInspector] public Transform parentAfterDrag;
 
    public TooltipTrigger tooltipTrigger;

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("Start Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData){
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
        tooltipTrigger.content = itemData.tooltext;
        tooltipTrigger.header = itemData.itemName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
