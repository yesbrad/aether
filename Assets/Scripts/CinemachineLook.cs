using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineLook : MonoBehaviour
{
    [Range(0f, 10f)] public float LookSpeed = 1f;
    public bool InvertY = false;
    private CinemachineFreeLook _freeLookComponent;
    private CinemachineVirtualCamera cam;

    public void Start()
    {
        _freeLookComponent = GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        //cam.
    }

}
