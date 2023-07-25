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
    public List<Choice> currentChoices;
    bool continuing;
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
        dialogueIsPlaying = true;
        ContinueStory();
    }
    // Moves through the story and updates text with currentStory.Continue()
    // also switches the modes between puzzle and reader modes
    private void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            //TODO: Send text to Log and to DisplayManager
            //dialogueText.text = currentStory.Continue();
            // TODO: Call Puzzle Manager when certain symbols are reached
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
    public void createCommand(int choiceNum, string name){
        Command newCommand = PuzzleManager.GetInstance().createCommand(choiceNum, name, currentStory.currentTags);
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
}
