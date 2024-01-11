using Assets.Scripts.Generic_Scriptables;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[BoxGroup("Movement"), SerializeField, Expandable] private ScriptableFloat moveSpeed;
		[Space]
		[BoxGroup("References"), SerializeField] private Rigidbody2D rb;

		private Controls controls;

		private void Awake()
		{
			controls = new Controls();

			controls.Player.Enable();

			controls.Player.Move.performed += Move;
			controls.Player.Move.canceled += Move;
		}

		private void OnDestroy()
		{
			controls.Player.Move.performed -= Move;
			controls.Player.Move.canceled -= Move;

			controls.Player.Disable();
		}

		private void OnDisable()
		{
			controls.Player.Move.performed -= Move;
			controls.Player.Move.canceled -= Move;

			controls.Player.Disable();
		}

		private void Move(InputAction.CallbackContext callbackContext)
		{
			Vector2 input = callbackContext.ReadValue<Vector2>();
			Debug.Log(input);

			if (input == Vector2.zero)
			{
				rb.velocity = Vector2.zero;
				return;
			}

			rb.velocity = input.normalized * moveSpeed.Value;
		}
	}
}
