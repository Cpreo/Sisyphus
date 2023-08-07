using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//MAKE SURE TO ADD BOTTOM PART WHEN WORKING WITH INPUTS
using UnityEngine.InputSystem;

public class R_CharControl : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private Vector2 moveInput = new Vector2 (0, 0); 


    [Range(0, 10f)] public float speed = 6f; //Speed of the player

    [SerializeField] public float gravity; //Downward force applied to player (m/s)

    void Start()
    {
        //References the Input Action Asset's script (found in the same folder as the input action) 
        playerControls = new PlayerControls();
        //playerInput = new PlayerInput();
        playerControls.Reality.Enable();


        //playerControls.Reality.Interact += Interact; Alternative method to directly subscribe to Inputs without InputAction Component
    }

    // Update is called once per frame
    void Update()
    {

        //Directly receives input from the playerControls asset. Should remain even if component removed from GameObject
        moveInput = playerControls.Reality.Move.ReadValue<Vector2>();
        
    }
    private void FixedUpdate()
    {
        controller.Move(new Vector3(moveInput.x * speed / 50, -gravity / 50, moveInput.y * speed / 50));
    }


    //Called When the player presses the "Interact" Button 
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Interact");
        }
    }

    //Called when the player inputs a new direction
    public void MoveReceive(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            //Debug.Log("Moving Here - " + context.ReadValue<Vector2>());
        }
    }
}
