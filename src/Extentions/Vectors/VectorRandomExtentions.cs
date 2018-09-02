using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
    public static partial class VectorExtentions {
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
    }
}