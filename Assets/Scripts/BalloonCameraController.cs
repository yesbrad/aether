using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BalloonCameraController : MonoBehaviour
{
	public Transform target;
	public float speed = 5;
	public float rotateSpeed;
	public float rotateSmoothness;
	public Transform offset;
	public Transform ballonPos;
	public float zoomSpeed = 1;

	private Vector3 rotation;

	private Vector3 pos;

	private Vector3 originalPos;

	bool isBalloon;

	private void Awake()
	{
		originalPos = offset.localPosition;
	}

	public void Switch (bool sw)
	{
		isBalloon = sw;
	}

	private void LateUpdate()
	{
		offset.transform.localPosition = Vector3.Lerp(offset.localPosition, isBalloon ? ballonPos.localPosition : originalPos, zoomSpeed * Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
		transform.Rotate(rotation * rotateSpeed * Time.deltaTime, Space.Self);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
	}

	public void OnLook(Vector2 input)
	{
		rotation.x = input.y;
		rotation.y =  -input.x;
	}
}
