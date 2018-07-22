using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
    public static class GradientHelper {
        public static Gradient CreateGradientFromHex(params string[] colorHexs) {
            float spacing = 1 / colorHexs.Length;

            Gradient g = new Gradient();

            List<GradientColorKey> colors = new List<GradientColorKey>();

            float time = 0;
            foreach (string hex in colorHexs) {
                colors.Add(new GradientColorKey(HexColorConverter.HexToColor(hex), time));
                time += spacing;
            }

            colors.Add(new GradientColorKey(HexColorConverter.HexToColor(colorHexs[0]), 1));

            g.SetKeys(colors.ToArray(), new GradientAlphaKey[] { new GradientAlphaKey(1, 0), new GradientAlphaKey(1, 1) });

            return g;
        }
    }
}