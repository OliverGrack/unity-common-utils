using UnityEngine;

namespace UCU {
    [CreateAssetMenu]
    public class FloatVariable : Variable<float> {
        public void SetValue(float value) {
            Value = value;
        }

        public void SetValue(FloatVariable value) {
            Value = value.Value;
        }

        public void ApplyChange(float amount) {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount) {
            Value += amount.Value;
        }
    }
}