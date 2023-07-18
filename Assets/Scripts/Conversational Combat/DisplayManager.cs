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
    

    public static DisplayManager GetInstance(){
        return instance;
    }
    // are we in puzzle mode or reader mode
    bool puzzle_mode;
    // stores list of commands that are drawn so we know when to draw more!
    List<Command> drawnCommands;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
