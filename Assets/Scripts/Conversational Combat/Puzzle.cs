using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{


    List<Item> validItems;
    // The list of total commands available to this puzzle, decides what can be drawn in
    List<Command> availableCommands;
    // These are the list of Commands that are active, and should be Drawn by Display
    List<Command> activeCommands;
    
    int player_health;
    int enemy_health;

    // List of items currently in the crafting pool
    List<Item> currentIngredients;


    public Puzzle(Command[] commands) {
        foreach(Command command in commands)
        {
            availableCommands.Add(command);
            foreach( Item ingredient in command.ingredients) {
                validItems.Add(ingredient);
            }
        }
        
    }


    // Called by DisplayManager when item is dragged in
    public void AddIngredient(Item ingredient) {
        if( validItems.Contains(ingredient)) {
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

    // Called by the DisplayManager. Makes a choice based on the data
    void UseCommand(Command command){
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
