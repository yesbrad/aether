﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private HeroController hero;
    private BalloonController balloon;
    private BalloonCameraController balloonCamera;
    private PlayerManager pawnSwapManager;

    public void Init()
    {
        hero = FindObjectOfType<HeroController>();
        balloon = FindObjectOfType<BalloonController>();
        balloonCamera = FindObjectOfType<BalloonCameraController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        hero.OnMove(input);
        balloon.OnMove(input);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        balloonCamera.OnLook(input);
    }

    public void OnInflate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            balloon.Inflate();
        }
    }

    public void OnDeflate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            balloon.Deflate();
        }
    }

    public void OnSwitch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameManager.PlayerManager.Switch();
        }
    }

    public void OmJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameManager.PlayerManager.Hero.OnJump();
        }
    }
}
