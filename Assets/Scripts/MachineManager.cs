using UnityEngine;
using System.Collections;
using UnityEditor;

public class MachineManager : MonoBehaviour
{
	public Pipe[] pipes;
	public MachineBlock[] blocks;

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

	[MenuItem("Tools/Rename Pipes")]
	public static void RenamePipes()
	{
		Pipe[] pipes = FindObjectsOfType<Pipe>();

		foreach (Pipe pipe in pipes)
		{
			pipe.name = pipe.settings ? pipe.settings.pipeID : "Pipe: MISSING SETTINGS";
		}
	}
}
