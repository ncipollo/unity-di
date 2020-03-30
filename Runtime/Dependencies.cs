using System.Collections.Generic;
namespace UnityDI {
    public class Dependencies {
        private Dictionary<DependencyKey, object> FactoryByKey;

        public T Get<T>(string name = "") {
            var key = new DependencyKey(name, typeof(T));
            return (T)FactoryByKey[key];
        }
    }
}