using UnityEngine;

public class Controller : MonoBehaviour
{
	public bool IsLocked { get; set; }

	public Pawn Pawn { get; private set; }

	public bool HasPawn { get { return Pawn != null; } }

	public Camera MainCamera { get; private set; }

	public bool Initialized { get; private set; }

	public virtual void Init ()
	{
		MainCamera = Camera.main;
		Initialized = true;
	}

	public void SetPawn (Pawn pawn)
	{
		Pawn = pawn;
	}

	public void RemovePawn ()
	{
		Pawn = null;
	}
}


