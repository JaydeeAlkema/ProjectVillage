using UnityEngine;

namespace Assets.Scripts.GenericScriptables
{
	[CreateAssetMenu(fileName = "ScriptableInt", menuName = "ScriptableObjects/ScriptableInt", order = 1)]
	public class ScriptableInt : ScriptableObject
	{
		public int Value;
	}
}
