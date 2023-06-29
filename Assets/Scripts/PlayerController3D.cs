using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
public class PlayerController3D : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController characterController;
    public float speed = 6;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move(){
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.SimpleMove(speed * Time.deltaTime * move);

    }
}
