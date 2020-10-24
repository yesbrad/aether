using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stand Settings", menuName = "Balloon Stand Settings")]
public class BalloonStandSettings : ScriptableObject
{
	[Range(0, 1)]
	public float heatAmount = 0.8f;
}
