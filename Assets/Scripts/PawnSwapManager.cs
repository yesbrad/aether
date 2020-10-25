using Cinemachine;
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

	public void Switch (bool forced = false)
	{
		if (isBalloon)
		{
			if (balloon.IsGrounded || forced)
			{
				hero.enabled = true;
				balloon.enabled = false;
				hero.controller.enabled = false;
				hero.transform.position = balloon.transform.position;
				hero.controller.enabled = true;
				pawn.transform.parent = hero.transform;
				pawn.transform.localPosition = Vector3.zero;
				hero.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
				balloon.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
				isBalloon = false;
			}
		}
		else
		{
			if(Vector3.Distance(hero.transform.position, balloon.transform.position) < 2 || forced)
			{
				hero.enabled = false;
				balloon.enabled = true;
				pawn.transform.parent = balloon.transform;
				pawn.transform.localPosition = Vector3.zero;
				hero.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
				balloon.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
				isBalloon = true;
			}
		}

	}
}
