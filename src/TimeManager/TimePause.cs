using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
	public static partial class TimeManager {
		public class Pause : System.IDisposable {
			public bool Paused { get; private set; }

			public Pause() {
				Paused = false;
			}

			public void StartPause() {
				if (!Paused) {
					AddPauseLayer();
					Paused = true;
				}
			}

			public void EndPause() {
				if (Paused) {
					RemovePauseLayer();
					Paused = false;
				}
			}

			public void TogglePause() {
				if (Paused) {
					EndPause();
				} else {
					StartPause();
				}
			}

			public void Dispose() {
				Debug.Log("Time Pause dispose");
				EndPause();
			}
		}
	}
}
