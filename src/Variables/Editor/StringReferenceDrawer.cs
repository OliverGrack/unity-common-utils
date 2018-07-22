using UnityEditor;
using UnityEngine;

namespace UCU.Editor {
    [CustomPropertyDrawer(typeof(StringReference))]
    public class StringReferenceDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty type = property.FindPropertyRelative("ValueType");
            SerializedProperty constantValue = property.FindPropertyRelative("ConstantValue");
            SerializedProperty variable = property.FindPropertyRelative("Variable");

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            StringReference.Type typeValue = (StringReference.Type)type.enumValueIndex;
            
            var typeRect = new Rect(position.x, position.y, 85, position.height);
            var valueRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

            EditorGUI.PropertyField(typeRect, type, GUIContent.none);
            EditorGUI.PropertyField(valueRect,
                typeValue == StringReference.Type.StringVariable ? variable : constantValue,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck()) {
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}