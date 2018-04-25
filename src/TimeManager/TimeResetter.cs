using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class TimeManager {
    public class TimeResetter : MonoBehaviour {

        void Start() {
            TimeManager.Reset();
        }
    }
}