using System;
using UnityEngine;

namespace UCU {
    [Serializable]
    public class StringReference {
        public enum Type {
            Value,
            StringVariable,
            RemoteSetting,
            LanguageString,
            RemoteLanguageString,
        }
        public Type ValueType;
        public string ConstantValue;
        public StringVariable Variable;

        public string Value {
            get {
                switch (ValueType) {
                    case Type.Value: return ConstantValue;
                    case Type.StringVariable: return Variable.Value;
                    case Type.RemoteSetting: return RemoteSettings.GetString(ConstantValue);
                    case Type.LanguageString: return I18n.Get(ConstantValue);
                    case Type.RemoteLanguageString: return I18n.Get(RemoteSettings.GetString(ConstantValue));
                    default: throw new Exception("Invalid type");
                }
            }
        }
    }
}
