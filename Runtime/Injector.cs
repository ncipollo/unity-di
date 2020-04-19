using System;

namespace UnityDI {
    public class Injector {
        private readonly Dependencies dependencies;

        public Injector() {
            dependencies = new Dependencies();
        }

        public void Module(Action<Module> moduleFactory) {
            var module = new Module(dependencies);
            moduleFactory(module);
        }

        public T Get<T>(string name = "", Parameters parameters = default) => dependencies.Get<T>(name, parameters);

        public T Inject<T>(string name = "", Parameters parameters = default) => Get<T>(name, parameters);
    }
}