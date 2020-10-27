using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSource : MachineBlock
{
	[SerializeField]
	private PipeType pipeType;

	public override void Init()
	{
		base.Init();
		Flow(pipeType, true);
	}

	public override void Flow(PipeType type, bool flow)
	{
		for (int i = 0; i < machineOutputs.Count; i++)
		{
			machineOutputs[i].Pipe.Flow(type, flow);
		}
	}
}
