using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;
    //Will be used to store horizontal  movement of player
    float direction = 0;
    //Speed at which the player moves
    public float speed = 400;
    //Declare RB to control physics and movement
    public Rigidbody2D playerRB;

    //Creates new instance of player controls
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Movement.MovementLR.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

    }
    //Updates velocity to move player left and right
    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(direction * speed, playerRB.velocity.y);
    }
}