using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Generic_Scriptables
{
	[CreateAssetMenu(fileName = "Scriptable Bool", menuName = "ScriptableObjects/Scriptable Bool")]
	public class ScriptableBool : ScriptableObject
	{
		public bool Value;
		public bool resetOnDestroy = true;
		[ShowIf("resetOnDestroy")] public bool resetValue;

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