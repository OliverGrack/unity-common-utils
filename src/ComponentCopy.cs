using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UCU {
	public static class ComponentCopy {

		public static T CopyComponent<T>(T original, GameObject destination) where T : Component {
			System.Type type = original.GetType();
			Component copy = destination.AddComponent(type);
			System.Reflection.FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic);
			foreach (System.Reflection.FieldInfo field in fields) {
				field.SetValue(copy, field.GetValue(original));
			}
			return copy as T;
		}

		public static void MergeGameObject(GameObject target, GameObject source) {
			Component[] components = source.GetComponents<Component>();
			foreach (Component component in components) {
				if (component is Transform) {
					continue;
				}
				try {
					CopyComponent(component, target);
				} catch {
					Debug.LogWarning("Could not copy component " + component.GetType().Name);
				}
			}
		}
	}
}
