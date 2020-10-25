using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour, ICharacter
{
    public CharacterController controller;
    public float speed = 5;
    public float gravity = 20;
    private Vector3 moveInput;
    private Vector3 movePosition;

    public bool IsLocked { get; set; }
    public bool IsGrounded => controller.isGrounded;

    private Camera mainCam;
    private Vector3 pos;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        movePosition = moveInput;
        movePosition = mainCam.transform.TransformDirection(movePosition);
        pos.x = movePosition.x * speed;
        pos.z = movePosition.z * speed;
        pos.y -= gravity * Time.deltaTime;
        controller.Move(pos * Time.deltaTime);
    }

    public void OnMove(Vector2 input)
    {
        moveInput.x = input.x;
        moveInput.z = input.y;
    }
}
