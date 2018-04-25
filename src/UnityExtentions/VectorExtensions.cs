using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions {
    /// <summary>
    /// Rounds the individual components, of the vector.
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="accuracy">Minimum not roundet number</param>
    /// <returns></returns>
    public static Vector2 Round(this Vector2 vec, float accuracy) {
        return new Vector2(
            Mathf.Round(vec.x / accuracy) * accuracy,
            Mathf.Round(vec.y / accuracy) * accuracy
        );
    }
    /// <summary>
    /// Rounds the individual components, of the vector.
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="accuracy">Minimum not roundet number</param>
    /// <returns></returns>
    public static Vector3 Round(this Vector3 vec, float accuracy) {
        return new Vector3(
            Mathf.Round(vec.x / accuracy) * accuracy,
            Mathf.Round(vec.y / accuracy) * accuracy,
            Mathf.Round(vec.z / accuracy) * accuracy
        );
    }
    /// <summary>
    /// Randomizes the direction of a vector
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="amount">0 no randomization, 1 any direction</param>
    /// <returns></returns>
    public static Vector2 RandomizeDirection(this Vector2 vec, float amount) {
        if (amount == 0) {
            return vec;
        }
        Vector2 random = Random.insideUnitCircle;
        Vector2 result = Vector2.Lerp(vec, random, amount);
        return result.normalized * vec.magnitude;
    }

    /// <summary>
    /// Randomizes the direction of a vector
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="amount">0 no randomization, 1 any direction</param>
    /// <returns></returns>
    public static Vector3 RandomizeDirection(this Vector3 vec, float amount) {
        if (amount == 0) {
            return vec;
        }
        Vector3 random = Random.insideUnitSphere;
        Vector3 result = Vector3.Lerp(vec, random, amount);
        return result.normalized * vec.magnitude;
    }
    /// <summary>
    /// Randomizes magnitute of vector
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="amount">example: 0.2 --> 20% +- of original vector magnitute   </param>
    /// <returns></returns>
    public static Vector3 RandomizeMagnitude(this Vector3 vec, float amount) {
        float random = 1 + Random.value * amount;
        return vec * random;
    }
    /// <summary>
    /// Randomizes magnitute of vector
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="amount">example: 0.2 --> 20% +- of original vector magnitute   </param>
    /// <returns></returns>
    public static Vector2 RandomizeMagnitude(this Vector2 vec, float amount) {
        float random = 1 + Random.value * amount;
        return vec * random;
    }

    /// <summary>
    /// Sets the magnitute of a vector, without changing the direction
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="mag"></param>
    /// <returns></returns>
    public static Vector3 WithMagnitude(this Vector3 vec, float mag) {
        return vec.normalized * mag;
    }
    /// <summary>
    /// Sets the magnitute of a vector, without changing the direction
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="mag"></param>
    /// <returns></returns>
    public static Vector3 WithMagnitude(this Vector2 vec, float mag) {
        return vec.normalized * mag;
    }

    public static Vector3 CutZeroComponents(this Vector3 vec) {
        if (vec.x < 0) vec.x = 0;
        if (vec.y < 0) vec.y = 0;
        if (vec.z < 0) vec.z = 0;
        return vec;
    }
}
