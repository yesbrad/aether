using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineConnector : MachineBlock
{
	[SerializeField]
	private bool startOn;

	public bool isOn;

	public override void Init()
	{
		base.Init();
	}

	public override void OnReciveFlow(GasType type, bool flow)
	{
		//selectFlowSlot = Mathf.Clamp(-1, machineOutputs.Count - 1, selectFlowSlot);

		if(startOn && flow)
		{
			isOn = true;
			startOn = false;
		}

		for (int i = 0; i < machineOutputs.Count; i++)
		{
			machineOutputs[i].Pipe.OnReciveFlow(type, isOn && flow);
		}

	}

	public override void OnReciveUtility(bool isOneShot)
	{
		isOn = !isOn;

		print("HE;;p");

		for (int i = 0; i < machineOutputs.Count; i++)
		{
			machineOutputs[i].Pipe.OnReciveFlow(currentGas, isOn);
		}

		for (int i = 0; i < UtilityOutputs.Count; i++)
		{
			UtilityOutputs[i].Pipe.OnReciveFlow(currentGas, isOn);
		}

		base.OnReciveUtility(isOneShot);
	}
}
