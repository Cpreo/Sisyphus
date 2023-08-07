using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Display : MonoBehaviour
{
    // Start is called before the first frame update
    /*
By: Ore Popoola
Display
Controls the drawing of all the UI elements 

is told by the DisplayManager to be in Reader or Puzzle Mode
Displays the proper Command when told to
Display the clickable log text
Displays the Inventory
Displays the Health

Displays the Chat window

Activates/Deactivates UI elements

*/
    private static Display instance;
    public GameObject inventory_window;
    public GameObject portraits_window;

    public GameObject log_window;
    private TextMeshProUGUI log_text;
    public GameObject chat;
    private TextMeshProUGUI chat_text;

    public GameObject craft_window;
    public GameObject command_prefab;
    

    // stores command button prefabs, so they can be destroyed; Is this too much data?
    List<GameObject> drawn_commands;

    bool puzzle_mode;// if true puzzle mode, if false, reader mode;


    private void Awake()
    {
        if(instance != null)
        {

        }
        instance = this;
    }
    public static Display GetInstance()
    {
        return instance;
    }
    
    public void UpdateChat(string newText){
        chat_text.text = newText;
    }

    void Start()
    {
        chat_text = chat.GetComponentInChildren<TextMeshProUGUI>();
    }
    // Draws Log, Gets Text from Log class, as well as gets all of the clickable Text objects.
    // TODO: Should handle logic on dragging text from log into crafting window at later date. in displayManager?
    public void DrawLog(){
        log_window.SetActive(true);
        // Get Text from displayManager
        GameObject logTextObject = GameObject.FindWithTag("Log Window");
        TextMeshProUGUI logText = logTextObject.GetComponent<TextMeshProUGUI>();
        logText.text = Log.GetInstance().GetText();
    }
    public void DrawInventory() {
        inventory_window.SetActive(true);
    }
    // special IEnumerator method with text not appearing instantly
    public void DrawChat() {
        chat.SetActive(true);
    }
    
    // Maybe break into enable crafting window and disable crafting window methods.
    public void DrawCraft() {
        craft_window.SetActive(true);
        //TODO: Drawing Commands

    }
    public void DrawCommand(Command command) {
        GameObject command_element = Instantiate(command_prefab);
        Command_UI properties = command_element.GetComponent<Command_UI>();
        properties.command = command;
        command_element.transform.SetParent(craft_window.transform,false);
        drawn_commands.Add(command_element);
        // Add ID to make it easier to destroy?
    }

    public void RemoveCommand(Command command){
        GameObject selectedButton = null;
        foreach(GameObject command_element in drawn_commands){
            Command_UI properties = command_element.GetComponent<Command_UI>();
            if(System.Object.ReferenceEquals(properties.command,command)) {
                selectedButton =command_element;
                // May need to add to independent Queue
            }
        }
        if(selectedButton != null)
        {
            Destroy(selectedButton);
        }
    }

    // Do we need this, should be handled by DisplayManager actually
    public void ChangeMode() {
    
    }
    //Visual novel like reader. No need for Inventory, but log might be nice, or available in 
    // a separate window if 
    public void ReaderMode(){

    }
    public void PuzzleMode() {
        DrawLog();
        DrawInventory();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
