using Assets.Scripts.Generic_Scriptables;
using Assets.Scripts.GenericScriptables;
using Assets.Scripts.Interfaces;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
	public class PlayerInteract : MonoBehaviour
	{
		[SerializeField, Expandable] private ScriptableInt interactionDamage;
		[SerializeField, Expandable] private ScriptableFloat interactionDistance;
		[SerializeField] private LayerMask interactLayerMask;

		private Controls controls;

		private void Awake()
		{
			controls = new Controls();

			controls.Player.Enable();

			controls.Player.Interact.performed += Interact;
		}

		private void OnDisable()
		{
			controls.Player.Interact.performed -= Interact;
		}

		private void OnDestroy()
		{
			controls.Player.Interact.performed -= Interact;
		}

		private void Interact(InputAction.CallbackContext callbackContext)
		{
			Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance.Value, interactLayerMask);
			foreach (var collider in colliders)
			{
				if (collider.TryGetComponent(out IDamageable damageable))
				{
					damageable.TakeDamage(interactionDamage.Value);
				}
				else if (collider.TryGetComponent(out IInteractable interactable))
				{
					interactable.Interact();
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (interactionDistance == null) return;
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, interactionDistance.Value);
		}
	}
}