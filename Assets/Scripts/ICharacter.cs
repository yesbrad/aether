
using UnityEngine.InputSystem;

interface ICharacter
{
	bool IsLocked { get; set; }

	bool IsGrounded { get; }
}

