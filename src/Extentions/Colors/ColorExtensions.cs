using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
    public static partial class ColorExtensions {
        /// <summary>
        /// </summary>
        /// <param name="color"></param>
        /// <param name="factor">0 -> color, 1 -> white</param>
        /// <returns></returns>
        public static Color Lighten(this Color color, float factor) {
            return Color.Lerp(color, Color.white, factor);
        }

        /// <summary>
        /// Returns a Color with the red value overritten
        /// </summary>
        /// <param name="color">Original Color</param>
        /// <param name="red">New Red value</param>
        /// <returns></returns>
        public static Color WithR(this Color color, float red) {
            return new Color(red, color.g, color.b, color.a);
        }

        /// <summary>
        /// Returns a Color with the green value overritten
        /// </summary>
        /// <param name="color">Original Color</param>
        /// <param name="green">New green value</param>
        /// <returns></returns>
        public static Color WithG(this Color color, float green) {
            return new Color(color.r, green, color.b, color.a);
        }

        /// <summary>
        /// Returns a Color with the blue value overritten
        /// </summary>
        /// <param name="color">Original Color</param>
        /// <param name="blue">New blue value</param>
        /// <returns></returns>
        public static Color WithB(this Color color, float blue) {
            return new Color(color.r, color.g, blue, color.a);
        }

        /// <summary>
        /// Returns a Color with the alpha value overritten
        /// </summary>
        /// <param name="color">Original Color</param>
        /// <param name="alpha">New alpha value</param>
        /// <returns></returns>
        public static Color WithA(this Color color, float alpha) {
            return new Color(color.r, color.g, color.b, alpha);
        }
    }
}