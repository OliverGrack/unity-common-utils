using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
	public static partial class TimeManager {
		public class TimeResetter : MonoBehaviour {

			private void Start() {
				TimeManager.Reset();
			}
		}
	}
}
