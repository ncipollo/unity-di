using System;
using System.Collections.Generic;
namespace UnityDI {
    public class Dependencies {
        private readonly Dictionary<DependencyKey, DependencyDefinition> Definitions;

        public Dependencies() {
            Definitions = new Dictionary<DependencyKey, DependencyDefinition>();
        }

        public T Get<T>(string name = "") {
            var key = new DependencyKey(name, typeof(T));
            return (T)Definitions[key].GetValue(this);
        }

        internal void Factory<T>(Func<Dependencies, object> factory, string name = "") {
            AddDefinition<T>(factory, name, false);
        }

        internal void Single<T>(Func<Dependencies, object> factory, string name = "") {
            AddDefinition<T>(factory, name, true);
        }

        private void AddDefinition<T>(Func<Dependencies, object> factory,
            string name,
            bool isSingleton) {
            var definition = new DependencyDefinition(factory, isSingleton);
            var key = new DependencyKey(name, typeof(T));

            Definitions[key] = definition;
        }
    }
}