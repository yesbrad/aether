using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSource : MachineBlock
{
	[SerializeField]
	private GasType pipeType;

	public override void Init()
	{
		base.Init();
		OnReciveFlow(pipeType, true);
	}

	public override void OnReciveFlow(GasType type, bool flow)
	{
		for (int i = 0; i < machineOutputs.Count; i++)
		{
			machineOutputs[i].Pipe.OnReciveFlow(type, flow);
		}
	}
}
