using UnityEngine;
using System;
using System.Collections.Generic;

namespace UCU {
	public class I18nException : Exception {

		public I18nException() : base() {
		}

		public I18nException(string message) : base(message) {
		}

		public I18nException(string message, Exception ex) : base(message, ex) {
		}
	}

	public static class I18n {
		public static string SelectedLanguage { get; private set; }

		public static string NumberFormat;

		public static Dictionary<string, string> CountingRules;
		public static LanguageConfig CurrentLanguage;

		// languageStrings contains all Strings of the currentlly selected Language
		private static Dictionary<string, string> languageStrings;

		private static bool initalized = false;

		private static I18nConfig config;

		private static void initalize() {
			config = Resources.Load<I18nConfig>("I18n/I18nConfig");
			CurrentLanguage = config.GetCurrectLanguage();
			SetLanguage(CurrentLanguage.IsoName);
		}

		/// <summary>
		/// loads new language from xml file
		/// and puts it into languageStrings
		/// </summary>
		/// <param name="lang">Corresponding Language isoCode (en, de, fr, ...), your files should have the same ones.</param>
		public static void SetLanguage(string lang) {
			SelectedLanguage = lang;

			languageStrings = LanguageFileLoader.LoadFile(lang);

			NumberFormat = languageStrings["countingRules.format"];
			CountingRules = GetCountingRules(languageStrings);
		}

		public static Dictionary<string, string> GetCountingRules(Dictionary<string, string> languageStrings) {
			var countingRules = new Dictionary<string, string>();
			foreach (var kvp in languageStrings) {
				string index = kvp.Key;
				if (index.StartsWith("countingRules.")) {
					countingRules[index.Replace("countingRules.", "")] = kvp.Value;
				}
			}

			return countingRules;
		}

		public enum ErrorType {
			LogAndReturnNull,
			LogAndThrow,
			Throw,
			ReturnNull
		}

		// GET return one string of the currently selected Language from index
		/// <summary>
		/// Gets String from activlly loaded Language-file
		/// </summary>
		/// <param name="index">JSON Path to the Language String</param>
		/// <returns>Returns string from index of the activlly loaded Language</returns>
		public static string Get(string index, ErrorType errorType = ErrorType.LogAndReturnNull) {
			// initalize if not already
			if (!initalized) {
				initalize();
			}

			// return string from index if exitsts
			string value;
			if (languageStrings.TryGetValue(index, out value)) {
				return value;
			} else {
				string errorMessage = String.Empty;
				if (errorType != ErrorType.ReturnNull) {
					errorMessage = $"Not included in language File: |{index}|";
				}

				if (errorType == ErrorType.LogAndReturnNull || errorType == ErrorType.LogAndThrow) {
					Debug.LogError(errorMessage);
				}
				if (errorType == ErrorType.LogAndThrow || errorType == ErrorType.Throw) {
					throw new I18nException(errorMessage);
				}
				return null;
			}
		}

		/// <summary>
		/// Gets Random String from an Language-Array.
		/// </summary>
		/// <param name="index">JSON Path to the Language Array</param>
		/// <returns>Random String from an LanguageArray</returns>
		public static string GetRandomArrayItem(string index, ErrorType errorType = ErrorType.LogAndReturnNull) {
			int length = Int32.Parse(Get(index + ".length"));

			float randomFloat = UnityEngine.Random.value * length;
			int randomIndex = (int)Math.Floor(randomFloat);

			return Get($"{index}[{randomIndex}]", errorType);
		}

		public static bool Includes(string index) {
			return languageStrings.ContainsKey(index);
		}

		/// <summary>
		/// Gets Language String, which contains a number {number} and uses the right form (singular/plural)
		/// You can configurate which form should be used for which numbers in the language-file of every language.
		/// </summary>
		/// <param name="index">JSON Path to the Number Object </param>
		/// <param name="number">Number to get right form for. Also will replace {number} in the language String if it is containt.</param>
		/// <returns>Corresponting String from NumberObject, with replcaed {number}</returns>
		public static string GetWithNumber(string index, float number) {
			//string RulePath = "countingRules." + number;

			string countingRuleToUse;

			if (CountingRules.ContainsKey(number.ToString())) {
				countingRuleToUse = CountingRules[number.ToString()];
			} else {
				countingRuleToUse = CountingRules["other"];
			}

			return Get(index + "." + countingRuleToUse).Replace("{number}", FormatNumber(number));
		}

		public static string FormatNumber(float number) {
			return number.ToString(NumberFormat);
		}

		/// <summary>
		/// Replaces all keys in dictioary with value
		/// Use "{number}€".LanguageReplace("{number}", "12"); returns 12€
		/// </summary>
		/// <param name="str"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string Evaluate(this string str, params string[] values) {
			int length = values.Length;
			for (int i = 0; i < length; i += 2) {
				str = str.Replace(values[i], values[i + 1]);
			}
			return str;
		}
	}
}
