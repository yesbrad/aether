using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMover : MachineBlock
{
	[SerializeField]
	private Transform mover;

	[SerializeField]
	private Vector3 toPosition;

	[SerializeField]
	private float time;

	private Vector3 originalPosition;

	private Vector3 targetpos;


	public override void Init()
	{
		base.Init();
		originalPosition = mover.position;
		targetpos = originalPosition;
	}

	private void Update()
	{
		mover.position = Vector3.MoveTowards(mover.position, targetpos, time * Time.deltaTime);
	}

	public override void OnReciveActivation(bool isActivate, bool isOneShot)
	{
		base.OnReciveActivation(isActivate, isOneShot);

		if (Flow)
		{
			targetpos = Activated ? originalPosition + toPosition : originalPosition;
		}

	}

	public override void OnReciveFlow(bool flow)
	{
		base.OnReciveFlow(flow);

		//if (!flow)
		//{
			//targetpos = originalPosition;
		//}
	}

	private void OnDrawGizmos()
	{
		if(mover)
			Gizmos.DrawWireSphere(mover.transform.position + toPosition, 0.2f);
	}
}
