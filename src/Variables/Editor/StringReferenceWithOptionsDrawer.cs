using UnityEditor;
using UnityEngine;

namespace UCU.Editor {
    [CustomPropertyDrawer(typeof(StringReferenceWithOptions))]
    public class StringReferenceWithOptionsDrawer : PropertyDrawer {

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return -2f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginChangeCheck();
            
            SerializedProperty stringRef = property.FindPropertyRelative("StringRef");
            SerializedProperty replaceBreaks = property.FindPropertyRelative("RepaceBreaks");
            SerializedProperty upperCase = property.FindPropertyRelative("UpperCase");

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(label);
            EditorGUILayout.PropertyField(stringRef, GUIContent.none);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(" - font style");
            replaceBreaks.boolValue = GUILayout.Toggle(replaceBreaks.boolValue, "Replace breaks", GUI.skin.button);
            upperCase.boolValue = GUILayout.Toggle(upperCase.boolValue, "Upper case", GUI.skin.button);
            EditorGUILayout.EndHorizontal();


            if (EditorGUI.EndChangeCheck()) {
                property.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}