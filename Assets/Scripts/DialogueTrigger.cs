using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    public bool playerInRange;

    private void Awake(){
        playerInRange = false;
        visualCue.SetActive(false);
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            Debug.Log("HI!");
        }
    }
    private void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            Debug.Log("Bye!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
}
