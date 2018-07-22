using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
    public static class CameraExtensions {
        /// <summary>
        /// Calculates the fieldOfView of a camera in X and Y componentents
        /// </summary>
        /// <param name="cam"></param>
        /// <returns>FieldOfView in Rad</returns>
        public static Vector2 CalcFieldOfView(this Camera cam) {
            float fieldOfViewY = cam.fieldOfView * Mathf.Deg2Rad;
            float fieldOfViewX = 2 * Mathf.Atan(Mathf.Tan(fieldOfViewY / 2) * cam.aspect);
            return new Vector2(fieldOfViewX, fieldOfViewY);
        }
    }
}