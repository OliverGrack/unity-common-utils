using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
	public static class StringHtmlExtentions {

		public static string TagBold(this string str) {
			return "<b>" + str + "</b>";
		}

		public static string TagColor(this string str, Color color) {
			string hex = color.ToHex();
			return "<color=#" + hex + ">" + str + "</color>";
		}

		public static string RepaceBreaks(this string str) {
			return str.Replace("<br>", Environment.NewLine);
		}
	}
}
