using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Resource
{
	public enum ResourceType { Empty, Stone, Coal, Iron, Copper, Silver, Gold, Oak, Pine, Birch }
	public class BaseNode : MonoBehaviour
	{
		[SerializeField] List<ResourceConfig> baseResourceConfigs;
		[SerializeField] List<ResourceConfig> specialResourceConfigs;
		List<Resource> baseResources;
		List<Resource> specialResources;

		protected void Awake()
		{
			foreach (var config in baseResourceConfigs)
			{
				baseResources.Add(config.Generate());
			}
			foreach (var config in specialResourceConfigs)
			{
				specialResources.Add(config.Generate());
			}

		}
		public (List<Resource> baseResources, List<Resource> specialResources) Gather() => (baseResources, specialResources);

		public class Resource
		{
			public ResourceType resourceType;
			public int amount;
		}
	}
}
