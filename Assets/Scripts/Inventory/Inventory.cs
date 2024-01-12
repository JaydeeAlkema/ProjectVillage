using Assets.Scripts.Collectables;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField] private Dictionary<Collectable, int> inventory = new Dictionary<Collectable, int>();

		public void AddItem(Collectable item)
		{
			if (inventory.Count == 0) inventory.Add(item, 1);
			foreach (KeyValuePair<Collectable, int> inventoryItem in inventory)
			{
				if (inventoryItem.Key.itemName == item.itemName)
				{
					inventory[inventoryItem.Key]++;
					return;
				}
				else
				{
					inventory.Add(item, 1);
					return;
				}
			}
		}

		public void RemoveItem(Collectable item)
		{
			if (inventory.ContainsKey(item))
			{
				inventory[item]--;
				if (inventory[item] <= 0) inventory.Remove(item);
			}
		}

		public Dictionary<Collectable, int> GetItems()
		{
			return inventory;
		}

		public void Clear()
		{
			inventory.Clear();
		}

		public int GetItemCount(Collectable item)
		{
			if (inventory.ContainsKey(item)) return inventory[item];
			else return 0;
		}

		public int GetTotalItemCount()
		{
			int total = 0;
			foreach (KeyValuePair<Collectable, int> item in inventory)
			{
				total += item.Value;
			}
			return total;
		}

		public int GetTotalItemWorth()
		{
			int total = 0;
			foreach (KeyValuePair<Collectable, int> item in inventory)
			{
				total += item.Key.itemWorth * item.Value;
			}
			return total;
		}

		[Button]
		public void PrintItems()
		{
			foreach (KeyValuePair<Collectable, int> item in inventory)
			{
				Debug.Log($"{item.Key.itemName} x{item.Value}");
			}
		}

		[Button]
		public void PrintTotalItemCount()
		{
			Debug.Log($"Total Item Count: {GetTotalItemCount()}");
		}

		[Button]
		public void PrintTotalItemWorth()
		{
			Debug.Log($"Total Item Worth: {GetTotalItemWorth()}");
		}
	}
}
