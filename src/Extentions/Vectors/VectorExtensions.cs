using UnityEngine;

namespace UCU {
    public static partial class VectorExtentions {
        /// <summary>
        /// Rounds the individual components, of the vector.
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="accuracy">Minimum not roundet number</param>
        /// <returns></returns>
        public static Vector2 Round(this Vector2 vec, float accuracy = 1f) {
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
        public static Vector3 Round(this Vector3 vec, float accuracy = 1f) {
            return new Vector3(
                Mathf.Round(vec.x / accuracy) * accuracy,
                Mathf.Round(vec.y / accuracy) * accuracy,
                Mathf.Round(vec.z / accuracy) * accuracy
            );
        }

        public static Vector3 CutZeroComponents(this Vector3 vec) {
            if (vec.x < 0) {
                vec.x = 0;
            }

            if (vec.y < 0) {
                vec.y = 0;
            }

            if (vec.z < 0) {
                vec.z = 0;
            }

            return vec;
        }

        public static Vector2 CutZeroComponents(this Vector2 vec) {
            if (vec.x < 0) {
                vec.x = 0;
            }

            if (vec.y < 0) {
                vec.y = 0;
            }

            return vec;
        }

        // axisDirection - unit vector in direction of an axis (eg, defines a line that passes through zero)
        // point - the point to find nearest on line for
        public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false) {
            if (!isNormalized) {
                axisDirection.Normalize();
            }

            var d = Vector3.Dot(point, axisDirection);
            return axisDirection * d;
        }

        // lineDirection - unit vector in direction of line
        // pointOnLine - a point on the line (allowing us to define an actual line in space)
        // point - the point to find nearest on line for
        public static Vector3 NearestPointOnLine(
            this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false) {
            if (!isNormalized) {
                lineDirection.Normalize();
            }

            var d = Vector3.Dot(point - pointOnLine, lineDirection);
            return pointOnLine + (lineDirection * d);
        }
    }
}
