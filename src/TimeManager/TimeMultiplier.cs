using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
	public static partial class TimeManager {
		public class TimeMultiplier {
			private float multiplier = 1;

			public float Multiplier {
				get {
					return multiplier;
				}
				set {
					if (multiplier != value) {
						TimeManager.RemoveMultiplier(multiplier);
						multiplier = value;
						TimeManager.AddMultiplier(multiplier);
					}
				}
			}

			public TimeMultiplier() {
				Multiplier = 1;
			}

			public TimeMultiplier(float muliplier) {
				Multiplier = muliplier;
			}

			public void Reset() {
				Multiplier = 1;
			}
		}
	}
}
