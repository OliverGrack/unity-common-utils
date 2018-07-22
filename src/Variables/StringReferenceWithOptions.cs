using System;

namespace UCU {
    [Serializable]
    public class StringReferenceWithOptions {
        public StringReference StringRef;
        public bool RepaceBreaks = false;
        public bool UpperCase = false;

        public string Value {
            get {
                string txt = StringRef.Value;

                if (RepaceBreaks) {
                    txt = txt.RepaceBreaks();
                }
                if (UpperCase) {
                    txt = txt.ToUpper();
                }

                return txt;
            }
        }
    }
}
