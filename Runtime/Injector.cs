using System;

namespace UnityDI {
    public class Injector {
        private readonly Dependencies dependencies;

        public static Injector Shared = new Injector();

        public Injector() {
            dependencies = new Dependencies();
        }

        public void Module(Action<Module> moduleFactory) {
            var module = new Module(dependencies);
            moduleFactory(module);
        }

        public T Get<T>(string name = "") => dependencies.Get<T>(name);

        public T Inject<T>(string name = "") => Get<T>(name);
    }
}