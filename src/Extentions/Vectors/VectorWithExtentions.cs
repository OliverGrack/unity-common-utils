using UnityEngine;

namespace UCU {
    public static partial class VectorExtentions {
        public static Vector2 xy(this Vector3 v) {
            return new Vector2(v.x, v.y);
        }

        public static Vector3 WithX(this Vector3 v, float x) {
            return new Vector3(x, v.y, v.z);
        }

        public static Vector3 WithY(this Vector3 v, float y) {
            return new Vector3(v.x, y, v.z);
        }

        public static Vector3 WithZ(this Vector3 v, float z) {
            return new Vector3(v.x, v.y, z);
        }

        public static Vector2 WithX(this Vector2 v, float x) {
            return new Vector2(x, v.y);
        }

        public static Vector2 WithY(this Vector2 v, float y) {
            return new Vector2(v.x, y);
        }

        public static Vector3 WithZ(this Vector2 v, float z) {
            return new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// Return a new vector, with diretion from vec and magnitute from mag parameter
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="mag"></param>
        /// <returns></returns>
        public static Vector3 WithMagnitude(this Vector3 vec, float mag) {
            return vec.normalized * mag;
        }
        /// <summary>
        /// Return a new vector, with diretion from vec and magnitute from mag parameter
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="mag"></param>
        /// <returns></returns>
        public static Vector2 WithMagnitude(this Vector2 vec, float mag) {
            return vec.normalized * mag;
        }

        public static Vector3 With(this Vector3 vec, float? x = null, float? y = null, float? z = null) {
            return new Vector3(
                x ?? vec.x,
                y ?? vec.y,
                z ?? vec.z
            );
        }

        public static Vector2 With(this Vector2 vec, float? x = null, float? y = null) {
            return new Vector2(
                x ?? vec.x,
                y ?? vec.y
            );
        }
    }
}
