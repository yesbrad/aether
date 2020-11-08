using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
	[SerializeField]
	private bool startWalking = false;

	public HeroController Hero { get; private set; }
	public BalloonController Balloon { get; private set; }
	
	private Pawn pawn;
	private BalloonCameraController cameraController;
	private bool isBalloon;

	public void Init()
	{
		pawn = FindObjectOfType<Pawn>();
		pawn.Init();
		cameraController = FindObjectOfType<BalloonCameraController>();
		Hero = FindObjectOfType<HeroController>();
		Hero.Init();
		Balloon = FindObjectOfType<BalloonController>();
		Balloon.Init();
		isBalloon = !startWalking;
		Switch(true);
	}

	public void Switch (bool forced = false)
	{
		if (isBalloon)
		{
			if (Balloon.controller.isGrounded || forced)
			{
				Hero.enabled = true;
				Balloon.enabled = false;

				pawn.LockPawn(false);
				pawn.SetPawnPosition(Balloon.transform.position);
				Hero.SetPawn(pawn);
				Balloon.RemovePawn();
				pawn.Switch(Hero);
				cameraController.Switch(false);

				Hero.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
				Balloon.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
				isBalloon = false;
			}
		}
		else
		{
			if(Vector3.Distance(pawn.transform.position, Balloon.transform.position) < 2 || forced)
			{
				Hero.enabled = false;
				Balloon.enabled = true;

				pawn.LockPawn(true);
				Balloon.SetPawn(pawn);
				Hero.RemovePawn();
				pawn.Switch(Balloon);
				cameraController.Switch(true);

				Hero.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
				Balloon.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
				isBalloon = true;
			}
		}

	}
}
