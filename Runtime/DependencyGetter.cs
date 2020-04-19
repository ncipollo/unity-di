namespace UnityDI {
    public class DependencyGetter {
        private Dependencies dependencies;
        public Parameters Parameters { get; }

        internal DependencyGetter(Dependencies dependencies, Parameters parameters) {
            this.dependencies = dependencies;
            Parameters = parameters;
        }

        public T Get<T>(string name = "", Parameters parameters = default) => dependencies.Get<T>(name, parameters);
        
        public T GetWithParams<T>(string name = "") => dependencies.Get<T>(name, Parameters);
    }
}