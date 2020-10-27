using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineConnector : MachineBlock
{
	public bool flowSelect;
	public int selectFlowSlot;

	public override void Flow(PipeType type, bool flow)
	{
		//selectFlowSlot = Mathf.Clamp(-1, machineOutputs.Count - 1, selectFlowSlot);

		if (!flowSelect)
		{
			for (int i = 0; i < machineOutputs.Count; i++)
			{
				machineOutputs[i].Pipe.Flow(type, flow);
			}
		}
		else
		{
			machineOutputs[selectFlowSlot].Pipe.Flow(type, flow);
		}
	}
}
