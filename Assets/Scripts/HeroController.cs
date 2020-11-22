using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : Controller
{
    private Vector3 moveInput;

    public bool IsMoving { get { return moveInput != Vector3.zero; } }

    public void OnMove(Vector2 input)
    {
        moveInput.x = input.x;
        moveInput.z = input.y;

        if (HasPawn)
        {
            Pawn.SetInput(moveInput);
        }
    }

    public void OnJump ()
    {
        Pawn.Jump();
    }
}
