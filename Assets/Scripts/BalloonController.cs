using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BalloonController : MonoBehaviour, ICharacter
{
    public CharacterController controller;
    public float speed = 5;
    [Range(0,1)]
    public float startHeat = 0.5f;
    public float baseLift = -10;
    public float maxLift = 10;
    public float accelerationSpeed = 0.1f;
    public float deflateMultiplier = 0.1f;
    public float inflateMultiplier = 0.1f;

    private float heat;
    private float lerpHeat;
    private Vector3 movePos;

    public bool IsLocked { get; set; }
    public bool IsGrounded => controller.isGrounded;

    private void Start()
    {
        heat = startHeat;
        PanelManager.instance.GamePanel.SetHeat(heat);
    }

    private void Update()
    {
        controller.Move(movePos * Time.deltaTime);
        lerpHeat = Mathf.Lerp(lerpHeat, heat, accelerationSpeed * Time.deltaTime);
        movePos.y = Mathf.Lerp(baseLift, maxLift, lerpHeat);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if(controller.isGrounded == false)
        {
            movePos.x = input.x * speed;
            movePos.z = input.y * speed;
        }
        else
        {
            movePos.x = 0;
            movePos.z = 0;
        }
    }

    public void OnInflate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AddHeat(inflateMultiplier);
        }
    }

    public void OnDeflate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AddHeat(-deflateMultiplier);
        }
    }

    public void AddHeat (float amt)
    {
        heat += amt;
        PanelManager.instance.GamePanel.SetHeat(heat);
    }
}
