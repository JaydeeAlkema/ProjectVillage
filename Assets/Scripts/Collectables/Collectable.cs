using UnityEngine;

namespace Assets.Scripts.Collectables
{
	public class Collectable : MonoBehaviour
	{
		public string itemName = "new Item";
		public string itemDescription = "Lorem Ipsum";
		public int itemWorth = 100;

		private BoxCollider2D boxCollider;

		private void OnEnable()
		{
			boxCollider = gameObject.AddComponent<BoxCollider2D>();
			boxCollider.isTrigger = true;
		}
	}
}
