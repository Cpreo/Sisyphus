using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
DisplayManager
By: Ore Popoola
Controls information about the display
Mediates information between log, inventory, puzzlemanager, and display


*/
public class DisplayManager : MonoBehaviour
{

    private static DisplayManager instance;
    
    [SerializeField] TextAsset inkJSON;
    public static DisplayManager GetInstance(){
        return instance;
    }
    // are we in puzzle mode or reader mode
    bool puzzle_mode;
    // stores list of commands that are drawn so we know when to draw more!
    List<Command> drawnCommands;
    // Start is called before the first frame update
    string interp_text;
    void Start()
    {
        // Ink Json asset should be stored somewhere else
        Interpreter.GetInstance().LoadStory(inkJSON);
    }

    // Update is called once per frame
    void Update()
    {
        interp_text = Interpreter.GetInstance().storyText;
        //    Display.GetInstance().UpdateChat(interp_text);
        // need section for log as well

        // will need to change depending on mode
        // note to self, should probabally do this stuff in phases so it is easier to test
        // I remember coding games in elementary school and with Tarang, what a jungle...
        if(Input.GetKeyDown(KeyCode.E) && Interpreter.GetInstance().continuing == false)
        {
            
            // should probabally have a unified method for updating all elements
            Interpreter.GetInstance().continuing = true;
            
            if(Interpreter.GetInstance().continuing)
            {
            Interpreter.GetInstance().ContinueStory();
            string storyText = Interpreter.GetInstance().storyText;
            Display.GetInstance().UpdateChat(storyText);
            // Need to get speaker tags
            Log.GetInstance().UpdateLog(Interpreter.GetInstance().storyText);
            Display.GetInstance().DrawLog();
            // We need to display the Log
            }
        }

    }

 
    //TODO: void for adding/removing ingredients on drag, talks to puzzlemanager

    // Adds a command to the UI by Instantiating the Command)
    // should definitely store list of currently active commands somehow
    // 

    /*
    * AddCommand: Tells the display to Draw a given command
    * Gets call from puzzlemanager class
    */
    public void AddCommand(Command command){
        Display.GetInstance().DrawCommand(command);
    }
    public void RemoveCommand(Command command){
        Display.GetInstance().RemoveCommand(command);
    }

    public void PuzzleChoice(Command command){
        PuzzleManager.GetInstance().GetPuzzle().UseCommand(command);
    }
}
