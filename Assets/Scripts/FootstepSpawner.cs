using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSpawner : MonoBehaviour
{
	public float detectionDistance = 0.1f;
	public ParticleSystem particleSystem;

	RaycastHit hit = new RaycastHit();

	public void Update()
	{
		if(Physics.Raycast(transform.position, Vector3.down, out hit, detectionDistance))
		{
			if(hit.collider.tag == "Untagged" && GameManager.PlayerManager.Hero.IsLocked == false && GameManager.PlayerManager.Hero.IsMoving)
				particleSystem.Emit(1);
		}
	}
}
	