using System;
using TMPro;
using UnityEngine;

namespace UCU {
	[ExecuteInEditMode]
	internal class LabelText : MonoBehaviour {
		public StringReferenceWithOptions Text;

		private void Start() {
			GetComponent<TMP_Text>().text = Text.Value;
		}

#if UNITY_EDITOR

		private void Update() {
			if (!Application.isPlaying) {
				Start();
			}
		}

#endif
	}
}
