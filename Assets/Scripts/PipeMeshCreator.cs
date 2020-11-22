using System.Collections.Generic;
using PathCreation.Utility;
using UnityEngine;
using UnityEditor;
using PathCreation.Examples;

[SelectionBase]
public class PipeMeshCreator : PathSceneTool {

	public PipeSettings settings;

	GameObject meshHolder;
	MeshFilter meshFilter;
	MeshRenderer meshRenderer;
	Mesh mesh;

	protected override void PathUpdated () {
		if (pathCreator != null) {
			AssignMeshComponents ();
			AssignMaterials ();
			CreateMesh ();
		}
	}

	[ContextMenu("UpdateMesh")]
	public void ForceUpdateMesh ()
	{
		CreateMesh(true);
	}

	void CreateMesh (bool forced = false) {
		List<Vector3> verts = new List<Vector3> ();
		List<int> triangles = new List<int> ();

		int numCircles = Mathf.Max (2, Mathf.RoundToInt (path.length * settings.resolutionV) + 1);
		var pathInstruction = PathCreation.EndOfPathInstruction.Stop;

		for (int s = 0; s < numCircles; s++) {
			float segmentPercent = s / (numCircles - 1f);
			Vector3 centerPos = path.GetPointAtTime (segmentPercent, pathInstruction);
			Vector3 norm = path.GetNormal (segmentPercent, pathInstruction);
			Vector3 forward = path.GetDirection (segmentPercent, pathInstruction);
			Vector3 tangentOrWhatEver = Vector3.Cross (norm, forward);

			for (int currentRes = 0; currentRes < settings.resolutionU; currentRes++) {
				var angle = ((float) currentRes / settings.resolutionU) * (Mathf.PI * 2.0f);

				var xVal = Mathf.Sin (angle) * settings.GetWidth();
				var yVal = Mathf.Cos (angle) * settings.GetWidth();

				var point = (norm * xVal) + (tangentOrWhatEver * yVal) + centerPos;
				verts.Add (point);

				//! Adding the triangles
				if (s < numCircles - 1) {
					int startIndex = settings.resolutionU * s;
					triangles.Add (startIndex + currentRes);
					triangles.Add (startIndex + (currentRes + 1) % settings.resolutionU);
					triangles.Add (startIndex + currentRes + settings.resolutionU);

					triangles.Add (startIndex + (currentRes + 1) % settings.resolutionU);
					triangles.Add (startIndex + (currentRes + 1) % settings.resolutionU + settings.resolutionU);
					triangles.Add (startIndex + currentRes + settings.resolutionU);
				}

			}
		}

		if (mesh == null || forced) {
			mesh = new Mesh();
		} else {
			mesh.Clear ();
		}

		mesh.SetVertices (verts);
		mesh.SetTriangles (triangles, 0);
		mesh.RecalculateNormals ();

	}

	// Add MeshRenderer and MeshFilter components to this gameobject if not already attached
	void AssignMeshComponents () {

		if (meshHolder == null) {
			meshHolder = new GameObject ("Mesh Holder");
			meshHolder.transform.parent = transform;
		}

		meshHolder.transform.rotation = Quaternion.identity;
		meshHolder.transform.position = Vector3.zero;
		meshHolder.transform.localScale = Vector3.one;

		// Ensure mesh renderer and filter components are assigned
		if (!meshHolder.gameObject.GetComponent<MeshFilter> ()) {
			meshHolder.gameObject.AddComponent<MeshFilter> ();
		}
		if (!meshHolder.GetComponent<MeshRenderer> ()) {
			meshHolder.gameObject.AddComponent<MeshRenderer> ();
		}

		meshRenderer = meshHolder.GetComponent<MeshRenderer> ();
		meshFilter = meshHolder.GetComponent<MeshFilter> ();
		if (mesh == null) {
			mesh = new Mesh ();
		}
		meshFilter.sharedMesh = mesh;
	}

	void AssignMaterials () {
		if (settings.material != null) {
			meshRenderer.sharedMaterial = settings.material;
		}
	}

}
