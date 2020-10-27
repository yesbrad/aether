using UnityEngine;
using System.Collections;
using UnityEditor;

public class MachineManager : MonoBehaviour
{
	public Pipe[] pipes;
	public MachineBlock[] blocks;

	private void Awake()
	{
		Init();
	}

	public void Init()
	{
		pipes = FindObjectsOfType<Pipe>();
		blocks = FindObjectsOfType<MachineBlock>();

		foreach (Pipe pipe in pipes)
		{
			pipe.Init();
		}
		
		foreach (MachineBlock block in blocks)
		{
			block.Init();
		}
	}

	[MenuItem("Tools/Rename Machines")]
	public static void RenameMachines()
	{
		MachineBlock[] blocks = FindObjectsOfType<MachineBlock>();

		foreach (MachineBlock block in blocks)
		{
			block.name = block.GetType().ToString();
		}
	}
}
