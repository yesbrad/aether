using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static PanelManager PanelManager { get; private set; }
	public static PlayerManager PlayerManager { get; private set; }
	public static InputManager InputManager { get; private set; }
	public static MachineManager MachineManager { get; private set; }

	private void Awake()
	{
		Init();
	}

	private void Init ()
	{
		PanelManager = FindObjectOfType<PanelManager>();
		PanelManager.Init();

		PlayerManager = FindObjectOfType<PlayerManager>();
		PlayerManager.Init();

		InputManager = FindObjectOfType<InputManager>();
		InputManager.Init();

		MachineManager = FindObjectOfType<MachineManager>();
		MachineManager.Init();
	}
}
