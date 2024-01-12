using Assets.Scripts.Interfaces;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
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
					Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropDistance;
					GameObject drop = new GameObject($"{resource.resourceType}");
					drop.transform.position = dropPosition;
					drop.transform.localScale = resource.scale * Vector3.one;
					SpriteRenderer spriteRenderer = drop.AddComponent<SpriteRenderer>();
					spriteRenderer.sprite = resource.sprite;
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
		public Sprite sprite;
		public ResourceType resourceType;
		public int amount;
		public float scale;
	}
}
