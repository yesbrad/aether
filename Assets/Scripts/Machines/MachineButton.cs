using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class MachineButton : MachineBlock
{
	[SerializeField]
	private GameObject button;

	[SerializeField]
	private float moveDistance = 0.1f;

	[SerializeField]
	private float moveSpeed = 0.3f;

	[SerializeField]
	private MeshRenderer buttonRenderer;

	[SerializeField]
	private bool buttonOneShot = false;

	[SerializeField]
	private bool startOn = true;

	private float emission = 0;

	public override void Init()
	{
		base.Init();

		if(startOn){
			Activated = true;
		}
	}

	private void Update()	
	{
		emission = Mathf.Lerp(emission, Activated ? 100 : 0, Time.deltaTime * 3);
		buttonRenderer.material.SetFloat("_Emission", emission);
	}

	public void UseButton (bool activate)
	{
		OnReciveActivation(activate, buttonOneShot);

		for (int i = 0; i < Outputs.Count; i++)
		{
			Outputs[i].Pipe.OnReciveActivation(activate, buttonOneShot);
		}
	}

	public void AnimateButtion () 
	{	
		if (buttonOneShot)
		{
			LeanTween.moveLocalY(button, button.transform.localPosition.y - moveDistance, moveSpeed).setOnComplete(() =>
			{
				LeanTween.moveLocalY(button, button.transform.localPosition.y + moveDistance, moveSpeed);
			});
		}
		else
		{
			if (Activated)
			{
				LeanTween.moveLocalY(button, button.transform.localPosition.y - moveDistance, moveSpeed);
			}
			else
			{
				LeanTween.moveLocalY(button, button.transform.localPosition.y + moveDistance, moveSpeed);
			}
		}	
	}

	public override void OnReciveActivation(bool isActivate, bool isOneShot)
	{
		base.OnReciveActivation(isActivate, isOneShot);
		AnimateButtion();
	}

	private void OnTriggerEnter(Collider other)
	{
		Pawn controller = other.GetComponent<Pawn>();

		if(controller != null)
		{
			UseButton(!Activated);
		}
	}

	private void OnTriggerExit (Collider other)
	{
		Pawn controller = other.GetComponent<Pawn>();

		if(controller != null && !buttonOneShot)
		{
			UseButton(false);
		}
	}
}
