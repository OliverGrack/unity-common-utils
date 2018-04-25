using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityFormatStringExtentions {
    public static string TagBold(this string str) {
        return "<b>" + str + "</b>";
    }
    public static string TagColor(this string str, Color color) {
        string hex = color.ToHex();
        return "<color=#" + hex + ">" + str + "</color>";
    }
}
