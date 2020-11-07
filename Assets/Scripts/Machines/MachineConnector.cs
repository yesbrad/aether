using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineConnector : MachineBlock
{
	[SerializeField]
	private bool startOn;

	public bool UtilityInitailized { get; set; }

	public override void Init()
	{
		base.Init();
	}

	public override void OnReciveFlow( bool flow)
	{
		//selectFlowSlot = Mathf.Clamp(-1, machineOutputs.Count - 1, selectFlowSlot);
		base.OnReciveFlow( flow);
		Debug.Log($"{gameObject.name} Revived flow! FLOW: {Flow}");

		if(startOn)
		{
			Activated = true;
			UtilityInitailized = true;
		}

		if(UtilityInitailized)
		{
			for (int i = 0; i < Outputs.Count; i++)
			{
				Debug.Log($"{gameObject.name} Flow: {Flow} and Activated: {Activated}", gameObject);
				Outputs[i].Pipe.OnReciveFlow(Activated == true && Flow == true);
			}
		}

		UtilityInitailized = true;
		startOn = false;
	}

	public override void OnReciveActivation(bool isActivate, bool isOneShot)
	{
		base.OnReciveActivation(isActivate, isOneShot);

		for (int i = 0; i < Outputs.Count; i++)
		{
			Outputs[i].Pipe.OnReciveFlow(Activated);
		}

		for (int i = 0; i < Outputs.Count; i++)
		{
			Outputs[i].Pipe.OnReciveActivation(Activated, isOneShot);
		}
	}
}
