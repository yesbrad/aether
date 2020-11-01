using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class MachineBlock : MonoBehaviour, IFlowListener, IUtilityListener
{
	public enum BlockInteractors
	{
		MachineInput,
		MachineOutput,
		UtilityInput,
		UtilityOuput,
	}

	public List<MachineInteractor> machineInputs = new List<MachineInteractor>();
	public List<MachineInteractor> machineOutputs = new List<MachineInteractor>();
	
	public List<MachineInteractor> UtilityInputs = new List<MachineInteractor>();
	public List<MachineInteractor> UtilityOutputs = new List<MachineInteractor>();

	public GasType currentGas;

	public virtual void Init ()
	{

	}

	public void AddInteractor(MachineInteractor input, BlockInteractors interactor)
	{
		switch (interactor)
		{
			case BlockInteractors.MachineInput: 
				machineInputs.Add(input); 
			break;
			case BlockInteractors.MachineOutput:
				machineOutputs.Add(input); 
			break;
			case BlockInteractors.UtilityInput:
				UtilityInputs.Add(input); 
			break;
			case BlockInteractors.UtilityOuput:
				UtilityOutputs.Add(input); 
			break;
		}
	}	
	
	public virtual void OnReciveFlow(GasType pipeType, bool flow)
	{
		currentGas = pipeType;
	}

	public virtual void OnReciveUtility(bool isOneShot)
	{
		for (int i = 0; i < UtilityOutputs.Count; i++)
		{
			UtilityOutputs[i].Pipe.OnReciveUtility(isOneShot);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, 2);
	}
}
