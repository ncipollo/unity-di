using System;
namespace UnityDI {
    public class DependencyDefinition {
        private readonly Func<Dependencies, object> FactoryFunction;
        private readonly bool IsSingleton;
        private object CachedValue;

        public DependencyDefinition(Func<Dependencies, object> factoryFunction, bool isSingleton) {
            FactoryFunction = factoryFunction;
            IsSingleton = isSingleton;
        }

        public object GetValue(Dependencies dependencies) {
            if (CachedValue != null) {
                return CachedValue;
            }

            var value = FactoryFunction(dependencies);
            if(IsSingleton) {
                CachedValue = value;
            }

            return value;
        }
    }

}