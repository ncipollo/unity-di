using System;
using System.Collections.Generic;
namespace UnityDI {
    public class Dependencies {
        private readonly Dictionary<DependencyKey, DependencyDefinition> definitions;

        public Dependencies() {
            definitions = new Dictionary<DependencyKey, DependencyDefinition>();
        }

        public T Get<T>(string name = "", Parameters parameters = default) {
            var key = new DependencyKey(name, typeof(T));
            var getter = new DependencyGetter(this, parameters ?? Parameters.Empty);
            
            return (T)definitions[key].GetValue(getter);
        }

        internal void Factory<T>(Func<DependencyGetter, object> factory, string name = "") {
            AddDefinition<T>(factory, name, false);
        }

        internal void Single<T>(Func<DependencyGetter, object> factory, string name = "") {
            AddDefinition<T>(factory, name, true);
        }

        private void AddDefinition<T>(Func<DependencyGetter, object> factory,
            string name,
            bool isSingleton) {
            var definition = new DependencyDefinition(factory, isSingleton);
            var key = new DependencyKey(name, typeof(T));

            definitions[key] = definition;
        }
    }
}