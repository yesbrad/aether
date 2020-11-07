using UnityEngine;
using System.Collections;
using PathCreation;

public enum GasType
{
	Normal,
	Air,
	Fire,
	Water
}

[RequireComponent(typeof(PipeMeshCreator))]
public class Pipe : MonoBehaviour, IFlowListener, IActivationListener
{
	PipeMeshCreator creator;
	PathCreator pathCreator;

	private bool isFlow;
	MachineInteractor input;
	MachineInteractor output;

	private float emission;

	MeshRenderer meshrenderer;

	public PipeSettings settings { get { return creator == null ? GetComponent<PipeMeshCreator>().settings : creator.settings; } }

	public void Init ()
	{
		pathCreator = GetComponent<PathCreator>();
		creator = GetComponent<PipeMeshCreator>();
		meshrenderer = GetComponentInChildren<MeshRenderer>();
		//SetFlowState(false);

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

	private void Update()
	{
		emission = Mathf.Lerp(emission, isFlow ? 2 : 0, Time.deltaTime * 10);
		meshrenderer?.material.SetFloat("_Emission", emission);	
		
	}

	public void OnReciveFlow(bool flow)
	{
		isFlow = flow;
		input.machineBlock.OnReciveFlow(flow);
	}

	public void OnReciveActivation(bool isActivate, bool isOneShot)
	{
		input.machineBlock.OnReciveActivation(isActivate, isOneShot);
	}
}
