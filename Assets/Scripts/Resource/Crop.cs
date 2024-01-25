using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Resource
{
	public class Crop : MonoBehaviour
	{
		[SerializeField, BoxGroup("Settings")] private List<CropStage> stages = new();
		[SerializeField, BoxGroup("Settings")] private int growTime = 0;
		[Space]
		[SerializeField, BoxGroup("Runtime")] private int currentStage = 0;
		[SerializeField, BoxGroup("Runtime")] private bool isWatered = false;
	}

	[Serializable]
	public struct CropStage
	{
		public string name;
		[ResizableTextArea] public string description;
		public Sprite Sprite;
	}
}
