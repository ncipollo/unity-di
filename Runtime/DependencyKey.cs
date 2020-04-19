using System;
namespace UnityDI {
    internal class DependencyKey {
        private readonly Tuple<string, Type> nameAndType;

        public DependencyKey(string name, Type type) {
            nameAndType = Tuple.Create(name, type);
        }

        public override int GetHashCode() => nameAndType.GetHashCode();

        public override bool Equals(object obj) {
            // If parameter is null return false.
            if (obj == null) {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            if (!(obj is DependencyKey otherKey)) {
                return false;
            }
            return  nameAndType.Equals(otherKey.nameAndType);
        }

        public override string ToString() => $"type: {nameAndType.Item2} and key: {nameAndType.Item1}";
    }
}