using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class MachineBlock : MonoBehaviour, IFlowController
{
	public List<MachineInput> machineInputs = new List<MachineInput>();
	public List<MachineOutput> machineOutputs = new List<MachineOutput>();

	public virtual void Init ()
	{

	}

	public void AddInput(MachineInput input)
	{
		machineInputs.Add(input);
	}	
	
	public void AddOutput(MachineOutput output)
	{
		machineOutputs.Add(output);
	}

	public virtual void Flow(PipeType pipeType, bool flow)
	{
	}
}
