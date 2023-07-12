using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
By: Ore Popoola
Takes transcript from interpreter and turns it into a scrollable log that is continually updated as the game progresses.
Inside the text are click and draggable statesments which are like items, this log autocreates items from the text to be used.

Extracts items from log
Reformats text into colorful things

*/

// sgo
public class Log : MonoBehaviour
{
    // Start is called before the first frame update
    // Text played up to this point
    string transcript;
    List<Item> cueItems;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLog(string newText){
        // adds new data to the log, called after the formatted text
        transcript += newText;
    }
    // Extracts items from transcript and formats it into something colorful to be displayed
    public string FormatTranscript(string incomingText)
    {
        int start1;
        int start2;
        // move start points after adding each new word as an item with the proper tooltext and Id;
        string formattedText = incomingText;
        //Extract Items from text;

        return formattedText;
    }
    // returns version of the log with colored text( might need to get into TextMeshPro), much todo here
    public string DisplayLog()
    {
        // sends the text log to maybe the display
        return transcript;
    }

}
