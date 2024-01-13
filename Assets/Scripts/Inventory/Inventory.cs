using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField] private Dictionary<Item, int> inventory = new Dictionary<Item, int>();

		public void AddItem(Item item)
		{
			foreach (KeyValuePair<Item, int> inventoryItem in inventory)
			{
				if (inventoryItem.Key.itemName.ToLower().Contains(item.itemName.ToLower()))
				{
					inventory[inventoryItem.Key]++;
					return;
				}
			}
			inventory.Add(item, 1);
			return;
		}

		public void RemoveItem(Item item)
		{
			if (inventory.ContainsKey(item))
			{
				inventory[item]--;
				if (inventory[item] <= 0) inventory.Remove(item);
			}
		}

		public Dictionary<Item, int> GetItems()
		{
			return inventory;
		}

		public void Clear()
		{
			inventory.Clear();
		}

		public int GetItemCount(Item item)
		{
			if (inventory.ContainsKey(item)) return inventory[item];
			else return 0;
		}

		public int GetTotalItemCount()
		{
			int total = 0;
			foreach (KeyValuePair<Item, int> item in inventory)
			{
				total += item.Value;
			}
			return total;
		}

		public int GetTotalItemWorth()
		{
			int total = 0;
			foreach (KeyValuePair<Item, int> item in inventory)
			{
				total += item.Key.itemWorth * item.Value;
			}
			return total;
		}

		[Button]
		public void PrintItems()
		{
			foreach (KeyValuePair<Item, int> item in inventory)
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
