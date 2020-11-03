using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private bool startOn = true;

	private bool isOn;
	private float emission = 0;

	public override void Init()
	{
		base.Init();

		isOn = startOn;
	}

	private void Update()	
	{
		emission = Mathf.Lerp(emission, isOn ? 100 : 1, Time.deltaTime);
		buttonRenderer.material.SetFloat("_Emission", emission);
	}

	public void UseButton ()
	{
		LeanTween.moveLocalY(button, button.transform.localPosition.y - moveDistance, moveSpeed).setOnComplete(() => {
			LeanTween.moveLocalY(button, button.transform.localPosition.y + moveDistance, moveSpeed);
		});

		isOn = !isOn;

		for (int i = 0; i < UtilityOutputs.Count; i++)
		{
			UtilityOutputs[i].Pipe.OnReciveUtility(true);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Pawn controller = other.GetComponent<Pawn>();

		if(controller != null)
		{
			UseButton();
		}
	}
}
