using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
Command_UI
By: Ore Popoola
Part of Command Button Prefab that controls what happens when it is clicked. The prefab is generated when 

*/
public class Command_UI : MonoBehaviour
{

    public Button command_button;
    public Command command;
    public int id;
    TextMeshProUGUI commandText;
    // Start is called before the first frame update
    void Start()
    {
        command_button = GetComponent<Button>();
        commandText = GetComponentInChildren<TextMeshProUGUI>();
        commandText.text = command.CommandName;
        command_button.onClick.AddListener(ClickCommand);
    }

    public void SetProperties()
    {
        commandText.text = command.CommandName;
    }
    public void ClickCommand(){
        // Eventually want to include several ways of responding when hitting a command
        //DisplayManager Controls whether this is active in the first place, should it direct logic as well?
        //Display Manager generates this object and destroys it
        DisplayManager.GetInstance().PuzzleChoice(command);
    }

    //TODO: Player will be able to choose a from a list of ways of articulating a confront/manipulate/ command
    // Will generate some options available to the player
    void GenerateOptions() {


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
