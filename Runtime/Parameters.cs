using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityDI {
    public class Parameters {
        private List<object> values;

        public static Parameters Empty { get; }

        static Parameters() {
            Empty = new Parameters();
        }

        public Parameters(params object[] values) {
            this.values = values.ToList();
        }

        public T Get<T>(int index) {
            try {
                return (T) values[index];
            }
            catch (ArgumentOutOfRangeException) {
                throw new MissingParameterException(index, typeof(T));
            }
            catch (InvalidCastException) {
                throw new MissingParameterException(index, typeof(T));
            }
        } 
    }
}