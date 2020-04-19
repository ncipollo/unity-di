using System;

namespace UnityDI {
    public class MissingDependencyException : Exception {
        internal MissingDependencyException(DependencyKey key) : base($"Missing dependency of {key}") {
        }
    }
}