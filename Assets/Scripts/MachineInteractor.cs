using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteractor : MonoBehaviour
{
	public MachineBlock machineBlock;

	private Pipe pipe;

	public Pipe Pipe { get { return pipe; } }

	public virtual void Init(Pipe pipe)
	{
		this.pipe = pipe;
		machineBlock = GetMachineBlock();
	}

	public MachineBlock GetMachineBlock()
	{
		MachineBlock[] blocks = FindObjectsOfType<MachineBlock>();

		for (int i = 0; i < blocks.Length; i++)
		{
			if (Vector3.Distance(blocks[i].transform.position, transform.position) < 1)//Vector3.Distance(currentBlock.transform.position, transform.position))
			{
				return blocks[i];
			}
		}

		Debug.Log("No Machine Block found for Interactor", gameObject);
		return null;
	}
}
