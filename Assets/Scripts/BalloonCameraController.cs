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

	private Vector3 rotation;

	private Vector3 pos;

	private void LateUpdate()
	{
		//pos += rotation;
		transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
		//transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(pos * rotateSpeed), rotateSmoothness * Time.deltaTime);

		transform.Rotate(rotation * rotateSpeed * Time.deltaTime, Space.Self);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
		//transform.e = 0;
		//transform.rotation = Quaternion.LookRotation(pos, Vector3.up);
		//transform.rotation = Quaternion.Euler(rotation);
	}

	public void OnLook(Vector2 input)
	{
		rotation.x = input.y;
		rotation.y =  -input.x;

		//if (input != Vector2.zero)
			//rotation += rotateSpeed * Time.deltaTime * input;
	}
}
