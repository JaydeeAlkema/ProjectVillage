using UnityEngine;

namespace Assets.Scripts
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Resource Config", fileName = "New Resource Config")]
	public class ResourceConfig : ScriptableObject
	{
		public ResourceType resourceType;
		public int minAmount;
		public int maxAmount;

		public Resource Generate()
		{
			return new Resource()
			{
				resourceType = resourceType,
				amount = Random.Range(minAmount, maxAmount)
			};
		}
	}
}
