using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
/*
By: Ore Popoola
Interpreter for Ink Storytime file
Loads in portions of the script
Is called by display and puzzle functions
Calls puzzle function when reaching certain symbols and hands off to that function which alters the display
Calls Log function to update the log, and communicates switches from reader to puzzle mode
If the ink json is the holy text, this is the church where it is allowed to be read. It cannot be read anywhere else.
*/
public class Interpreter : MonoBehaviour
{
    private Story currentStory;
    public bool dialogueIsPlaying;
    private static Interpreter instance;
    
    // list of current choices
    public List<Choice> currentChoices;
    // Is there more text to add after calling the function
    // TODO: potentially make function a bool
    public bool continuing;
    // doesn't need to be serializable
    public string storyText;
    private void Awake()
    {
        if(instance != null)
        {

        }
        instance = this;
    }
    // Static because only one Interpreter, shared by several classes
    // 
    public static Interpreter GetInstance()
    {
        return instance;
    }

    void Start() {
        dialogueIsPlaying = false;

    }

    public void LoadStory(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        currentStory.ObserveVariable("commandCount", (string commandCount, object newVal) => {
            createCommand(currentStory.variablesState["choiceNum"],currentStory.variablesState["commandName"]);
        });
        dialogueIsPlaying = true;
        ContinueStory();// This should probabally be in its own method
    }
    // Moves through the story and updates text with currentStory.Continue()
    // also switches the modes between puzzle and reader modes

    public void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            //TODO: Send text to Log and to DisplayManager
            //dialogueText.text = currentStory.Continue();
            // TODO: Call Puzzle Manager when certain symbols are reached
            continuing = true;
            storyText = currentStory.Continue();
            continuing = false;
            //TODO: Display choices available using Display Class
            //DisplayChoices();
        }
        else{
            // Exit Dialogue when 
            //ExitDialogueMode();
            continuing = false;
            
        }
    }
    // transcribes a puzzle from text into a list of commands that can be used in the puzzle
    public void createCommand(object choiceNum, object commandName){

        int numChoice = (int)choiceNum;
        string name = (string)commandName;
        Command newCommand = PuzzleManager.GetInstance().createCommand(numChoice, name, currentStory.currentTags);
        PuzzleManager.GetInstance().extractedCommands.Add(newCommand);
    }
    
    private void GetChoices()
    {
        // TODO: Send text to Log/ Diplay Manager
        currentChoices = currentStory.currentChoices;
    }
    public void MakeChoice(int choiceIndex){
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
    //Handling Input, may have to alter later
    public void Update()
    {
        
    }

}
