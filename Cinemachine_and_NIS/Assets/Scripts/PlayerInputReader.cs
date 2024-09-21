using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public PlayerInput playerControls;

    public delegate void PlayerInputDelegate();
    public event PlayerInputDelegate OnShoot;

    InputAction move;
    InputAction fire;

    void Awake()
    {
        playerControls = new PlayerInput();
    }

    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Shoot;
    }

    void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        OnShoot?.Invoke();
    }

    public Vector2 GetMoveDirection()
    {
        return move.ReadValue<Vector2>();
    }
}
