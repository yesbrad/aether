using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PipeType
{
	Level1,
	Level2,
	Level3,
	Level4,
	Utility
}

[CreateAssetMenu(fileName = "PipeSettings", menuName = "Pipe Settings")]
public class PipeSettings : ScriptableObject
{
	public string pipeID = "Pipe";
	public PipeType pipeType;
	public float width = 0.3f;
	[Range(3, 30)]
	public int resolutionU = 10;
	[Min(0)]
	public float resolutionV = 20;

	public Material material;

	public float GetWidth ()
	{
		return width;
	}
}
