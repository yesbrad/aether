using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineEnd : MachineBlock
{
	public override void Flow(PipeType type, bool flow)
	{
		Debug.Log("Hit the end: " + type.ToString());
	}
}
