using Assets.Scripts.Interfaces;
using Assets.Scripts.Inventory;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Resource
{
	public enum ResourceType { Empty, Stone, Coal, Iron, Copper, Silver, Gold, Oak, Pine, Birch }
	public class BaseNode : MonoBehaviour, IDamageable
	{
		[SerializeField] private int health = 100;
		[Space]
		[SerializeField, Expandable] List<ResourceConfig> baseResourceConfigs = new List<ResourceConfig>();
		[SerializeField, Expandable] List<ResourceConfig> specialResourceConfigs = new List<ResourceConfig>();
		[Space]
		[SerializeField] float dropDistance = 2f;

		List<Resource> baseResources = new List<Resource>();
		List<Resource> specialResources = new List<Resource>();

		protected void Awake()
		{
			baseResources.AddRange(baseResourceConfigs.Select(config => config.Generate()));
			specialResources.AddRange(specialResourceConfigs.Select(config => config.Generate()));
		}

		public (List<Resource> baseResources, List<Resource> specialResources) Gather()
		{
			return (baseResources, specialResources);
		}

		private void DropResources()
		{
			foreach (var resource in baseResources)
			{
				for (var i = 0; i < resource.amount; i++)
				{
					Vector2 randomPosition = Random.insideUnitCircle * dropDistance;
					GameObject GO = Instantiate(resource.prefab, transform.position + (Vector3)randomPosition, Quaternion.identity);
					GO.GetComponent<Item>().itemWorth = resource.worth;
				}
			}
		}

		public void TakeDamage(int damage)
		{
			health -= damage;
			if (health <= 0)
			{
				DropResources();
				Destroy(gameObject);
			}
		}
	}
	public class Resource
	{
		public GameObject prefab;
		public ResourceType resourceType;
		public int amount;
		public int worth;
		public string description;
	}
}
