using System;
namespace UnityDI {
    internal class DependencyKey {
        private readonly string Name;
        private readonly Type Type;
        private readonly Tuple<string, Type> NameAndType;

        public DependencyKey(string name, Type type) {
            Name = name;
            Type = type;
            NameAndType = Tuple.Create(Name, Type);
        }

        public override int GetHashCode() => NameAndType.GetHashCode();

        public override bool Equals(object obj) => NameAndType.Equals(obj);
    }
}