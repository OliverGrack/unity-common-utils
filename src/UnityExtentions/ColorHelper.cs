using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorHelper {
    public static Color AverageColor(params Color[] colors) {
        if (colors.Length == 1) {
            return colors[0];
        }

        float r = 0;
        float g = 0;
        float b = 0;
        float a = 0;

        foreach(Color c in colors) {
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
