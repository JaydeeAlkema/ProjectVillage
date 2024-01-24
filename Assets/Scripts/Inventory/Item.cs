using NaughtyAttributes;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class Item : MonoBehaviour
	{
		[SerializeField, BoxGroup("Settings")] private string itemName = "new Item";
		[SerializeField, BoxGroup("Settings")] private string itemDescription = "Lorem Ipsum";
		[SerializeField, BoxGroup("Settings")] private int itemWorth = 100;
		[SerializeField, BoxGroup("Settings")] private float itemActivationTime = 0.35f;
		[Space]
		[SerializeField, BoxGroup("References")] private GameObject OnPickupParticles = null;
		[SerializeField, BoxGroup("References"), Required] private BoxCollider2D boxCollider = null;

		#region Getters & Setters
		public string GetItemName()
		{
			return itemName;
		}
		public void SetItemName(string itemName)
		{
			this.itemName = itemName;
		}
		public string GetItemDescription()
		{
			return itemDescription;
		}
		public void SetItemDescription(string itemDescription)
		{
			this.itemDescription = itemDescription;
		}
		public int GetItemWorth()
		{
			return itemWorth;
		}
		public void SetItemWorth(int itemWorth)
		{
			this.itemWorth = itemWorth;
		}
		#endregion

		private void OnEnable()
		{
			StartCoroutine(OnInstantiateStartActivationTimer());
		}

		private void OnDestroy()
		{
			if (OnPickupParticles != null)
				Instantiate(OnPickupParticles, transform.position, Quaternion.identity);
		}

		private IEnumerator OnInstantiateStartActivationTimer()
		{
			yield return new WaitForSeconds(itemActivationTime);
			boxCollider.enabled = true;
			boxCollider.isTrigger = true;
		}
	}
}
