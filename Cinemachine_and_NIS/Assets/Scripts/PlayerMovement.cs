using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveDirection;

    Rigidbody2D playerRB;

    PlayerInputReader input;

    Player playerInfo = new Player();

    #region Unity Methods
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        input = gameObject.GetComponent<PlayerInputReader>();
    }

    void Update()
    {
        UpdateMoveDirection();
    }

    void FixedUpdate()
    {
        Movement();
    }
    #endregion

    #region Movement Logic
    // Determines movement direction based on input
    void UpdateMoveDirection()
    {
        moveDirection = input.GetMoveDirection();
    }

    // Calculates movement based on moveDirection
    void Movement()
    {
        playerRB.velocity = moveDirection * playerInfo.speed;
        CheckForScreenLimit(playerInfo.hScreenLimit, playerInfo.vScreenLimit);
    }

    // Prevents player from moving offscreen
    void CheckForScreenLimit(float hScreenLimit, float vScreenLimit)
    {
        if (transform.position.x > hScreenLimit || transform.position.x <= -hScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y > vScreenLimit || transform.position.y <= -vScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }
    #endregion
}
