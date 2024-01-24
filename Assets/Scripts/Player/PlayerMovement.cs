using Assets.Scripts.GenericScriptables;
using NaughtyAttributes;
using UnityEngine;

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
		}

		private void Update()
		{
			Move();
		}

		private void OnDestroy()
		{
			controls.Player.Disable();
		}

		private void OnDisable()
		{
			controls.Player.Disable();
		}

		private void Move()
		{
			Vector2 input = controls.Player.Move.ReadValue<Vector2>();

			if (input == Vector2.zero)
			{
				rb.velocity = Vector2.zero;
				return;
			}

			rb.velocity = input.normalized * moveSpeed.Value;
		}
	}
}
