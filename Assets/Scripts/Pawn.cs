using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float airSpeed = 3;

    [SerializeField]
    private float gravity = 20;

    [SerializeField]
    private float jumpForce = 100;
    
    [SerializeField]
    private Transform rotateContainer;

    public bool IsLocked { get; set; }
    public bool IsGrounded => controller.isGrounded;

    private Camera mainCam;
    private CharacterController controller;
    private Vector3 pos;
    private Vector3 moveInput;
    private Vector3 movePosition;

    private Controller currentController;

    private Animator animator;

    private Vector3 finalPosition;

    private bool jumpTrigger;
    private bool InCoolDownMode;

    public void Init()
    {
        controller = GetComponent<CharacterController>();
        mainCam = Camera.main;
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f))
        {
            //transform.SetParent(hit.collider.transform);

            if (transform != hit.transform || hit.transform == null)
                StartCoroutine(JumpCoolDown());

        }

        movePosition = mainCam.transform.TransformDirection(moveInput);
        movePosition.y = 0;

        float newSpeed = controller.isGrounded ? speed : airSpeed;

        pos.x = movePosition.x * newSpeed;
        pos.z = movePosition.z * newSpeed;
        // && animator.GetCurrentAnimatorStateInfo(0).IsName("Move")
        if (jumpTrigger && controller.isGrounded)
        {
            pos.y = jumpForce;
            animator.SetTrigger("Jump");
            jumpTrigger = false;
            InCoolDownMode = true;
        }

        if (pos.y > -gravity)
            pos.y -= gravity * Time.deltaTime;

        controller.Move(pos * Time.deltaTime);

        animator.SetBool("isGrounded", IsGrounded);
        animator.SetFloat("MoveBlend", Mathf.Lerp(animator.GetFloat("MoveBlend"), moveInput.magnitude, Time.deltaTime * 10));

        if (movePosition != Vector3.zero)
            rotateContainer.transform.localRotation = Quaternion.LookRotation(movePosition, Vector3.up);
    }

    IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(4);
        InCoolDownMode = false;

    }

    public void SetInput(Vector3 input)
    {
        moveInput = input;
    }

    public void Jump ()
    {
        jumpTrigger = true;
    }

    public void Switch(Controller controller)
    {
        currentController = controller;
        Parent(controller.transform);
    }

    public void Parent (Transform parent)
    {
        transform.position = parent.position;
        transform.parent = parent;
    }

    public void SetPawnPosition (Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }
}
