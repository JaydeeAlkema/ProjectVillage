using Assets.Scripts.Collectables;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField] private Dictionary<Collectable, int> items = new Dictionary<Collectable, int>();

		public void AddItem(Collectable item)
		{
			if (items.ContainsKey(item)) items[item]++;
			else items.Add(item, 1);
		}

		public void RemoveItem(Collectable item)
		{
			if (items.ContainsKey(item))
			{
				items[item]--;
				if (items[item] <= 0) items.Remove(item);
			}
		}

		public Dictionary<Collectable, int> GetItems()
		{
			return items;
		}

		public void Clear()
		{
			items.Clear();
		}

		public int GetItemCount(Collectable item)
		{
			if (items.ContainsKey(item)) return items[item];
			else return 0;
		}

		public int GetTotalItemCount()
		{
			int total = 0;
			foreach (KeyValuePair<Collectable, int> item in items)
			{
				total += item.Value;
			}
			return total;
		}

		public int GetTotalItemWorth()
		{
			int total = 0;
			foreach (KeyValuePair<Collectable, int> item in items)
			{
				total += item.Key.itemWorth * item.Value;
			}
			return total;
		}

		[Button]
		public void PrintItems()
		{
			foreach (KeyValuePair<Collectable, int> item in items)
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
