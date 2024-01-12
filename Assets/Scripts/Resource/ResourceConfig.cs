using UnityEngine;

namespace Assets.Scripts.Resource
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Resource Config", fileName = "New Resource Config")]
	public class ResourceConfig : ScriptableObject
	{
		public Sprite sprite;
		public ResourceType resourceType;
		public int minAmount;
		public int maxAmount;
		public float scale;
		public int worth;
		public string description;

		public Resource Generate()
		{
			return new Resource()
			{
				resourceType = resourceType,
				amount = Random.Range(minAmount, maxAmount),
				sprite = sprite,
				scale = scale,
				worth = worth,
				description = description
			};
		}
	}
}
