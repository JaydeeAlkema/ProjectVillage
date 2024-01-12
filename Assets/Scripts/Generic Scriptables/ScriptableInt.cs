using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.GenericScriptables
{
	[CreateAssetMenu(fileName = "Scriptable Int", menuName = "ScriptableObjects/Scriptable Int")]
	public class ScriptableInt : ScriptableObject
	{
		public int Value;
		public bool resetOnDestroy = true;
		[ShowIf("resetOnDestroy")] public int resetValue = 0;

		private void OnDestroy()
		{
			if (resetOnDestroy) Value = resetValue;
		}
		private void OnEnable()
		{
			if (resetOnDestroy) Value = resetValue;
		}
		private void OnDisable()
		{
			if (resetOnDestroy) Value = resetValue;
		}
	}
}
