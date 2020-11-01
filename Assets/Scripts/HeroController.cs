﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : Controller
{
    private Vector3 moveInput;

    public void OnMove(Vector2 input)
    {
        moveInput.x = input.x;
        moveInput.z = input.y;

        print(moveInput);

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
