using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCU {
	public static class LanguageFileLoader {

		public static Dictionary<string, string> LoadFile(string isoCode) {
			Dictionary<string, string> languageStrings = new Dictionary<string, string>();

			TextAsset textAsset = Resources.Load<TextAsset>("I18n/lang_" + isoCode);

			JSONNode json = JSON.Parse(textAsset.text);
			AnalizeJSONObject(languageStrings, json, "");

			return languageStrings;
		}

		/// <summary>
		/// Loads JSONObject into Language Dictionary
		/// also calculates Paths for JSON Elements (Strings, Arrays, Objects)
		/// </summary>
		/// <param name="json">JSON Object (could also be a child)</param>
		/// <param name="path">(Path of curretly analizing JSONObject</param>
		private static void AnalizeJSONObject(Dictionary<string, string> languageStrings, JSONNode json, string path) {
			// Works recurrsivly (calls its self with child objects
			if (json.IsString) {
				languageStrings[path] = json.Value;
			} else if (json.IsNumber) {
				languageStrings[path] = json.AsFloat.ToString();
			} else if (json.IsObject) {
				string currentPath = path;
				if (currentPath != "") {
					currentPath += ".";
				}

				foreach (var kvp in json) {
					var key = kvp.Key;
					var child = kvp.Value;

					string childPath = $"{currentPath}{key}";
					AnalizeJSONObject(languageStrings, child, childPath);
				}
			} else if (json.IsArray) {
				languageStrings[path + ".length"] = json.Count.ToString();
				int count = json.Count;
				for (int i = 0; i < count; i++) {
					string childPath = path + "[" + i + "]";
					AnalizeJSONObject(languageStrings, json[i], childPath);
				}
			}
		}
	}
}
