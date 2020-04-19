using System;
namespace UnityDI {
    public class DependencyDefinition {
        private readonly Func<DependencyGetter, object> factoryFunction;
        private readonly bool isSingleton;
        private object cachedValue;

        public DependencyDefinition(Func<DependencyGetter, object> factoryFunction, bool isSingleton) {
            this.factoryFunction = factoryFunction;
            this.isSingleton = isSingleton;
        }

        internal object GetValue(DependencyGetter getter) {
            if (cachedValue != null) {
                return cachedValue;
            }

            var value = factoryFunction(getter);
            if(isSingleton) {
                cachedValue = value;
            }

            return value;
        }
    }

}