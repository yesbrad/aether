using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Tools : MonoBehaviour
{
	[MenuItem("Tools/Fix Pipes")]
	public static void FixPipes ()
	{
		Pipe[] pipes = FindObjectsOfType<Pipe>();

		for (int i = 0; i < pipes.Length; i++)
		{
			int loop = pipes[i].transform.childCount;
			//List<Action> actions = new List<Action>();
			//var tempList = pipes[i].transform.Cast<Transform>().ToList();

			//Debug.Log(i);

			//foreach (var child in tempList)
			//{
			//DestroyImmediate(child.gameObject);
			//}

			while (pipes[i].transform.childCount != 0)
			{
				DestroyImmediate(pipes[i].transform.GetChild(0).gameObject);
			}


			for (int b = loop; b > 0; --b)
			{
				//actions.Add(() => {
					//Destroy(pipes[i].transform.GetChild(0));
				//});
			}

			//UnityEditor.EditorApplication.delayCall += () =>
			//{

				//for (int x = 0; x < actions.Count; x++)
				//{
					//actions[x].Invoke();
					//Debug.Log("Yeet");
				//}
			//};

			pipes[i].GetComponent<PipeMeshCreator>().TriggerUpdate();
		}
	}
}
