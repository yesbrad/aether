using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PawnSwapManager : MonoBehaviour
{
	public static PawnSwapManager instance;

	public bool startWalking = false;

	private Pawn pawn;
	private HeroController hero;
	private BalloonController balloon;

	public bool isBalloon;

	private void Awake()
	{
		instance = this;
		pawn = FindObjectOfType<Pawn>();
		hero = FindObjectOfType<HeroController>();
		balloon = FindObjectOfType<BalloonController>();
		isBalloon = !startWalking;
		Switch(true);
	}

	public void Switch (InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Switch(false);
		}
	}

	public void Switch (bool forced)
	{
		if (isBalloon)
		{
			if (balloon.IsGrounded || forced)
			{
				Debug.Log("Back to char");

				hero.enabled = true;
				balloon.enabled = false;
				hero.transform.position = balloon.transform.position;
				pawn.transform.parent = hero.transform;
				pawn.transform.localPosition = Vector3.zero;
				isBalloon = false;
			}
		}
		else
		{
			if(Vector3.Distance(hero.transform.position, balloon.transform.position) < 2 || forced)
			{
				Debug.Log("InBallon");

				hero.enabled = false;
				balloon.enabled = true;
				pawn.transform.parent = balloon.transform;
				pawn.transform.localPosition = Vector3.zero;
				isBalloon = true;
			}
		}

	}
}
