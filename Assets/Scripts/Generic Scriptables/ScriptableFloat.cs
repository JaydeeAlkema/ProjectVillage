using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Generic_Scriptables
{
	[CreateAssetMenu(fileName = "Scriptable Float", menuName = "ScriptableObjects/Scriptable Float")]
	public class ScriptableFloat : ScriptableObject
	{
		public float Value;
		public bool resetOnDestroy = true;
		[ShowIf("resetOnDestroy")] public float resetValue = 0;

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