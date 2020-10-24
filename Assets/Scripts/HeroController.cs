using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour, ICharacter
{
    public CharacterController controller;
    public float speed = 5;
    public float gravity = 20;
    private Vector3 movePos;
    private Vector3 movePosition;

    public bool IsLocked { get; set; }
    public bool IsGrounded => controller.isGrounded;

    private void Update()
    {
        if (controller.isGrounded)
        {
            movePosition = movePos;
            movePosition *= speed;
        }

        movePosition.y -= gravity * Time.deltaTime;
        controller.Move(movePosition * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        movePos.x = input.x * speed;
        movePos.z = input.y * speed;
    }
}
