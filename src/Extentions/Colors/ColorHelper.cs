using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
    public static partial class ColorHelper {
        public static Color AverageColor(params Color[] colors) {
            if (colors.Length == 1) {
                return colors[0];
            }

            float r = 0;
            float g = 0;
            float b = 0;
            float a = 0;

            foreach (Color c in colors) {
                r += c.r;
                g += c.g;
                b += c.b;
                a += c.a;
            }

            int colorCount = colors.Length;

            return new Color(
                r / colorCount,
                g / colorCount,
                b / colorCount,
                a / colorCount
            );
        }
    }
}