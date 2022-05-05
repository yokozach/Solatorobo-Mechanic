using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 6.0f;
    private float jumpHeight = 3.0f;
    private float gravityValue = -9.81f;
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    public states state;

    public enum states
    {
        Move, Stop


    }
    public void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        state = states.Move;
    }



    void Update()
    {
        switch (state)
        {
            case states.Move:
                CanMove();
                break;
            case states.Stop:
                cantmove();
                break;
        }
    }

    public void CanMove()
    {
        groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void cantmove()
    {
        state = states.Stop;
    }
    public void MechanicOver()
    {
        state = states.Move;
    }
}
