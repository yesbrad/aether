using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineConnector : MachineBlock
{
	[SerializeField]
	private PipeType[] outputTypes;

	[SerializeField]
	private PipeType[] inputRequirements;

	[SerializeField]
	private bool startOn;

	public bool UtilityInitailized { get; set; }

	public override void Init()
	{
		base.Init();
	}

	public override void OnReciveFlow( bool flow)
	{
		base.OnReciveFlow( flow);

		if(startOn)
		{
			Activated = true;
			UtilityInitailized = true;
		}

		if(UtilityInitailized)
		{
			for (int i = 0; i < Outputs.Count; i++)
			{
				for (int x = 0; x < outputTypes.Length; x++)
				{
					if(outputTypes[x] == Outputs[i].Pipe.settings.pipeType)
					{
						Debug.Log($"{gameObject.name} Flow: {Flow} and Activated: {Activated}", gameObject);
						Outputs[i].Pipe.OnReciveFlow(Activated == true && Flow == true);
					}
				}
			}
		}

		UtilityInitailized = true;
		startOn = false;
	}

	public override void OnReciveActivation(bool isActivate, bool isOneShot)
	{
		base.OnReciveActivation(isActivate, isOneShot);

		for (int i = 0; i < Outputs.Count; i++)
		{

			for (int x = 0; x < outputTypes.Length; x++)
			{
				if (outputTypes[x] == Outputs[i].Pipe.settings.pipeType)
				{
					Outputs[i].Pipe.OnReciveFlow(Activated);
				}
			}
		}

		for (int i = 0; i < Outputs.Count; i++)
		{
			Outputs[i].Pipe.OnReciveActivation(Activated, isOneShot);
		}
	}
}
