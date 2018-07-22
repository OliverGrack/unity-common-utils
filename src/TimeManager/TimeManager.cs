using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class TimeManager {

    private static int nrOfPauseLayers = 0;
    private static float timeMultiplier = 1;

    /*public static bool isPhysicsTimeScalling = true;

    public static bool IsPhysicsTimeScalling {
        get {
            return isPhysicsTimeScalling;
        }
        set {
            isPhysicsTimeScalling = value;
            apply();
        }
    }
    */


    public static void AddMultiplier(float multiplier) {
        timeMultiplier *= multiplier;
        Debug.Log("TimeManager: Add Multiplier. Multiplier " + timeMultiplier);
        apply();
    }
    public static void RemoveMultiplier(float multiplier) {
        timeMultiplier /= multiplier;
        Debug.Log("TimeManager: Remove Multiplier. Multiplier " + timeMultiplier);
        apply();
    }

    public static void AddPauseLayer() {
        nrOfPauseLayers++;
        Debug.Log("TimeManager: AddPauseLayer. Nr of Layers " + nrOfPauseLayers);
        apply();
    }

    public static void RemovePauseLayer() {
        if (nrOfPauseLayers > 0) {
            nrOfPauseLayers--;
            Debug.Log("TimeManager: RemovePauseLayer. Nr of Layers " + nrOfPauseLayers);
            apply();
        }
    }

    public static void ResetMultiplier() {
        timeMultiplier = 1;
        Debug.Log("TimeManager: ResetMultiplier. Multiplier" + timeMultiplier);
        apply();
    }

    public static void ResetPauseLayers() {
        nrOfPauseLayers = 0;
        Debug.Log("TimeManager: ResetPauseLayers. Nr of Layers " + nrOfPauseLayers);
        apply();
    }

    public static void Reset() {
        ResetMultiplier();
        ResetPauseLayers();
    }

    public static IEnumerator ShortMultiplier(float mutliplier, float time) {
        AddMultiplier(mutliplier);
        yield return new WaitForSecondsRealtime(time);
        RemoveMultiplier(mutliplier);
    }

    private static void apply() {
        float timeScale = 1;
        if (nrOfPauseLayers > 0) {
            timeScale = 0;
        } else {
            timeScale *= timeMultiplier;
        }
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = timeScale * 0.02f;
    }
}
