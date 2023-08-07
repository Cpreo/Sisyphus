using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
[RequireComponent(typeof(TooltipTrigger))] 
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Item itemData;
    private ConvoControls convoControls;
    [HideInInspector] public Transform parentAfterDrag;
 
    public TooltipTrigger tooltipTrigger;

    private void Awake()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData){
    
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData){
       
        transform.position = convoControls.Convo.MousePosition.ReadValue<Vector2>();
    }
    public void OnEndDrag(PointerEventData eventData) {
     
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
        tooltipTrigger.content = itemData.tooltext;
        tooltipTrigger.header = itemData.itemName;
        image.sprite = itemData.icon;

        //Enables mouse movement for New Input System
        convoControls = new ConvoControls();
        convoControls.Convo.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
