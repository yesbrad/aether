using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSource : MachineBlock
{
	public override void Init()
	{
		base.Init();
		OnReciveFlow(true);
	}

	public override void OnReciveFlow(bool flow)
	{
		for (int i = 0; i < Outputs.Count; i++)
		{
			Outputs[i].Pipe.OnReciveFlow(true);
		}
	}
}
