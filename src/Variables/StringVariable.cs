using UnityEngine;

namespace UCU {
    public class Variable<T> : ScriptableObject {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        [SerializeField]
        private T value = default(T);

        public T Value {
            get { return value; }
            set { this.value = value; }
        }

        public static implicit operator T(Variable<T> variable) {
            return variable.Value;
        }
    }
    [CreateAssetMenu]
    public class StringVariable : Variable<string> { }
}