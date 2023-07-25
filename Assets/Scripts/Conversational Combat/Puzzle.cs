using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    List<Item> validItems;
    // The list of total commands available to this puzzle, decides what can be drawn in
    List<Item> currentIngredients;
    // List of items currently in the crafting pool
    List<Command> availableCommands;
    // These are the list of Commands that are active, and should be Drawn by Display
    List<Command> activeCommands;
    //List of commands that have been drawn
    List<Command> drawnCommands;
    int player_health;
    int enemy_health;

    string hi;


    public Puzzle(List<Command> commands) {
        validItems = new List<Item>();
        currentIngredients = new List<Item>();
        availableCommands = new List<Command>();
        activeCommands = new List<Command>();
        drawnCommands = new List<Command>();
        
        foreach(Command command in commands)
        {
            availableCommands.Add(command);
            foreach( Item ingredient in command.ingredients) {
                validItems.Add(ingredient);
            }
        }
        
    }

    // Possible Change: move the Add/Remove Ingredient functions to the PuzzleManager
    // Called by DisplayManager when item is dragged in
    public void AddIngredient(Item ingredient) {
        if( validItems.Contains(ingredient)) {// bounce back item if it is not valid by calling a different command
        currentIngredients.Add(ingredient);
        }
    }
    // Called by DisplayManager when item is dragged out
    public void RemoveIngredient(Item ingredient) {
        currentIngredients.Remove(ingredient);
    }


    // When all required items for one of the Commands in the active puzzle are in place,
    // Remove the items, Add the command to the active ones, disable its recipe, remove its valid items from the pool
    void Craft() {
        foreach(Command command in availableCommands) {
            if(currentIngredients.Count >= command.ingredients.Count) {
                int ingredientCount = command.ingredients.Count;
                
                foreach(Item ingredient in currentIngredients)
                {
                    if(command.ingredients.Contains(ingredient)) {
                        ingredientCount -= 1;
                    }
                }
                if(ingredientCount == 0) {
                    activeCommands.Add(command);
                    // Add new command to active ones
                    foreach( Item item in command.ingredients)
                    {
                        currentIngredients.Remove(item);
                        // Remove all crafting materials
                    }
                }
            }
        }
        // make sure items in active commands are not in available commands
        foreach(Command command in activeCommands)
        {
            if(availableCommands.Contains(command)){
                availableCommands.Remove(command);
            }
        }

    }


    void Draw(){
        // call displaymanager for each active command 
        // how do we make sure there is no duplicates though?
        foreach(Command active in activeCommands){
            // Make sure commands are not in active ones
            if(!drawnCommands.Contains(active)){
            DisplayManager.GetInstance().AddCommand(active);
            }
            
            drawnCommands.Add(active);
        }
    }

    // Called by the DisplayManager. Makes a choice based on the data
    // Should this be in the DisplayManager? We may be able to have different types of puzzles
    // later down the road....
    public void UseCommand(Command command){
        Interpreter.GetInstance().MakeChoice(command.choiceNum);

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
