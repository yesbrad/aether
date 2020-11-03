using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMover : MachineBlock
{
	[SerializeField]
	private Transform mover;

	public bool isOn;

	[SerializeField]
	private Vector3 toPosition;

	[SerializeField]
	private float time;
	private Vector3 originalPosition;

	public override void Init()
	{
		base.Init();
		originalPosition = mover.localPosition;
	}

	public override void OnReciveFlow(GasType type, bool flow)
	{
		base.OnReciveFlow(type, flow);
	}

	public override void OnReciveUtility(bool isOneShot)
	{
		if (Flow)
		{
			isOn = !isOn;

			if (isOn)
			{
				LeanTween.moveLocal(mover.gameObject, originalPosition + toPosition, time);
			}
			else
			{
				LeanTween.moveLocal(mover.gameObject, originalPosition, time);
			}
		}

		for (int i = 0; i < UtilityOutputs.Count; i++)
		{
			UtilityOutputs[i].Pipe.OnReciveFlow(currentGas, isOn);
		}

		base.OnReciveUtility(isOneShot);
	}

	private void OnDrawGizmos()
	{
		if(mover)
		Gizmos.DrawWireSphere(mover.transform.position + toPosition, 0.2f);
	}
}
