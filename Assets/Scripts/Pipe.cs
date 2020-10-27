using UnityEngine;
using System.Collections;
using PathCreation;

public enum PipeType
{
	Normal,
	Air,
	Fire,
	Water
}

[RequireComponent(typeof(PathCreator))]
public class Pipe : MonoBehaviour, IFlowController
{
	PathCreator pathCreator;

	private bool isFlow;
	MachineInput input;
	MachineOutput output;

	MeshRenderer meshrenderer;

	public void Init ()
	{
		pathCreator = GetComponent<PathCreator>();
		meshrenderer = GetComponentInChildren<MeshRenderer>();
		SetFlowState(false);

		AddInteractors();
	}

	void AddInteractors()
	{
		input = new GameObject().AddComponent<MachineInput>();
		input.gameObject.name = "Input";
		input.transform.parent = transform;
		input.transform.localPosition = pathCreator.bezierPath.GetPoint(pathCreator.bezierPath.NumPoints - 1);
		input.Init(this);

		output = new GameObject().AddComponent<MachineOutput>();
		output.gameObject.name = "Output";
		output.transform.parent = transform;
		output.transform.localPosition = pathCreator.bezierPath.GetPoint(0);
		output.Init(this);
	}

	public void SetFlowState (bool flow)
	{
		isFlow = flow;
		meshrenderer.material.SetFloat("_Emission", isFlow ? 2 : 0);	
	}

	public void Flow(PipeType pipeType, bool flow)
	{
		Debug.Log("Flowed Throught the pipe");
		SetFlowState(flow);
		input.machineBlock.Flow(pipeType, flow);
	}
}
