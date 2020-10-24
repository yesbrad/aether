using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonStand : MonoBehaviour
{
	public BalloonStandSettings settings;

	public void OnTriggerEnter(Collider other)
	{
		BalloonController controller = other.GetComponent<BalloonController>();

		if (controller)
		{
			controller.AddHeat(settings.heatAmount);
		}
	}
}
