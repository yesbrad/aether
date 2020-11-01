using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BalloonController : Controller
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
    private Vector3 movePosition;
    private Vector3 pos;

    public override void Init()
    {
        heat = startHeat;
        GameManager.PanelManager.GamePanel.SetHeat(heat);
    }

    private void Update()
    {
        if (!Initialized)
            return;

        movePosition = movePos;
        movePosition = MainCamera.transform.TransformDirection(movePosition) * speed;
        
        pos.x = movePosition.x;
        pos.z = movePosition.z;

        if (controller.isGrounded)
        {
            pos.x = 0;
            pos.z = 0;
        }

        controller.Move(pos * Time.deltaTime);
        lerpHeat = Mathf.Lerp(lerpHeat, heat, accelerationSpeed * Time.deltaTime);
        pos.y = Mathf.Lerp(baseLift, maxLift, lerpHeat);
    }

    public void OnMove(Vector2 input)
    {
        if(controller.isGrounded == false)
        {
            movePos.x = input.x;
            movePos.z = input.y;
        }
    }

    public void Inflate()
    {
        AddHeat(inflateMultiplier);
    }

    public void Deflate()
    {
        AddHeat(-deflateMultiplier);
    }

    public void AddHeat (float amt)
    {
        heat += amt;
        GameManager.PanelManager.GamePanel.SetHeat(heat);
    }
}
