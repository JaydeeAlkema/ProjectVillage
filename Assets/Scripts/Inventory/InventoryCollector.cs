using Assets.Scripts.Collectables;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class InventoryCollector : MonoBehaviour
	{
		public Inventory Inventory;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent(out Collectable collectable))
			{
				Inventory.AddItem(collectable);
				Destroy(collision.gameObject);
			}
		}
	}
}