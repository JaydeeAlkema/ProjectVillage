using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public enum ResourceType { Empty, Stone, Coal, Iron, Copper, Silver, Gold, Oak, Pine, Birch }
	public class BaseNode : MonoBehaviour
	{
		[SerializeField] ResourceConfig baseResourceConfig;
		[SerializeField] ResourceConfig specialResourceConfig;
		Resource baseResource;
		Resource specialResource;

		protected void Awake()
		{
			baseResource = baseResourceConfig.Generate();
			specialResource = specialResourceConfig.Generate();
		}

		public Resource Gather() => baseResource;
		public Resource GatherSpecial() => specialResource;
	}

	public class Resource
	{
		public ResourceType resourceType;
		public int amount;
	}
}
