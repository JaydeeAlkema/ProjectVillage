using UnityEngine;

namespace Assets.Scripts.Resource
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Resource Config", fileName = "New Resource Config")]
	public class ResourceConfig : ScriptableObject
	{
		public GameObject prefab;
		public ResourceType resourceType;
		public int minAmount;
		public int maxAmount;
		public int worth;
		public string description;

		public Resource Generate()
		{
			return new Resource()
			{
				prefab = prefab,
				resourceType = resourceType,
				amount = Random.Range(minAmount, maxAmount),
				worth = worth,
				description = description
			};
		}
	}
}
