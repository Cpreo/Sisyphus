using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
By: Ore Popoola
PuzzleManager
Called by the Interpreter
Handles the fighting between Therapist and Client

This class takes control once the interpreter reads a certain symbol

This class switches the display manager from reader to puzzle mode
It takes in input from the display manager based on which items are dragged in from the inventories or Log
It updates the health and Story values based on player actions once given control. These values are in DisplayManager
It switches control back to the interpreter once the puzzle is finished

Tells displayManager which commands to Draw
It handles the use of commands and their effect on the enemy

*/
public class PuzzleManager : MonoBehaviour
{
    private static PuzzleManager  instance;

    List<Item> validItems;
    // The list of total commands available to this puzzle, decides what can be drawn in
 
    // Current Puzzle be played
    Puzzle activePuzzle = null;

    // Are we in puzzle mode? Important for DisplayManager, and Interpreter
    bool isActive = false;
    
    private void Awake()
    {
        if(instance != null)
        {

        }
        instance = this;
    }
    public static PuzzleManager GetInstance()
    {
        return instance;
    }


    public void CreatePuzzle(Command[] commands)
    {
        isActive = true;
        activePuzzle = new Puzzle(commands);
    }

    // Hands the potato back to the interpreter, to continue on its merry way
    public void EndPuzzle(){
        // check if puzzle is in a fail or win state, and update accordingly
        isActive = false;
        activePuzzle = null;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(isActive){

            
        }
    }
}
