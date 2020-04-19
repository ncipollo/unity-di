using System;

namespace UnityDI {
    public class MissingParameterException : Exception {
        internal MissingParameterException(int index, Type type): base($"type: {type} at index: {index}") {
        }
    }
}