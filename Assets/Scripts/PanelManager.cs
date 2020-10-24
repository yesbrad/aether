using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
	public static PanelManager instance;

	[SerializeField]
	private GamePanel gamePanel;
	public GamePanel GamePanel { get { return gamePanel; } }

	private void Start()
	{
		instance = this;
	}
}
