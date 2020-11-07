using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class MachineBlock : MonoBehaviour, IFlowListener, IActivationListener
{
	public enum BlockInteractors
	{
		MachineInput,
		MachineOutput,
		UtilityInput,
		UtilityOuput,
	}

	public List<MachineInteractor> Inputs = new List<MachineInteractor>();
	public List<MachineInteractor> Outputs = new List<MachineInteractor>();

	public bool Flow { get; private set; }

	public bool Activated { get; set; }

	public virtual void Init ()
	{

	}

	public void AddInput(MachineInput input)
	{
		Inputs.Add(input);
	}

	public void AddOutput(MachineOutput output)
	{
		Outputs.Add(output);
	}

	public virtual void OnReciveFlow(bool flow)
	{
		Flow = flow;
	}

	public virtual void OnReciveActivation(bool isActivate, bool isOneShot)
	{
		Activated = isActivate;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, 2);
	}
}
