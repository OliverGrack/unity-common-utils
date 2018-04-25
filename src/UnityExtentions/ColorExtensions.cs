using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtendions {
    public static Color lightenColor(this Color color, float factor) {
        float invers = 1 - factor;
        return new Color(
            factor + color.r * invers,
            factor + color.g * invers,
            factor + color.b * invers,
            color.a
        );
    }
}
