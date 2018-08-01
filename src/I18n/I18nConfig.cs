using SubjectNerd.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UCU {
	[Serializable]
	public class LanguageConfig {
		public SystemLanguage SystemLanguage;
		public string IsoName;
		public bool FallbackLanguage;
	}

	[CreateAssetMenu(fileName = "I18nConfig.asset", menuName = "I18nConfig")]
	public class I18nConfig : ScriptableObject, ISerializationCallbackReceiver {

		[Reorderable]
		public LanguageConfig[] Languages;

		public LanguageConfig GetFallbackLanguage() {
			return Languages.Where(lang => lang.FallbackLanguage).FirstOrDefault();
		}

		public LanguageConfig GetCurrectLanguage() {
			var systemLanguage = Application.systemLanguage;
			return Languages.Where(lang => lang.SystemLanguage == systemLanguage).FirstOrDefault() ?? GetFallbackLanguage();
		}

		public void OnBeforeSerialize() {
		}

		public void OnAfterDeserialize() {
#if UNITY_EDITOR
			if (GetFallbackLanguage() == null) {
				Debug.LogError("No fallback Language specified");
			}
#endif
		}
	}
}
