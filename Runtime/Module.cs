using System;
namespace UnityDI {
    public class Module {
        private readonly Dependencies dependencies;

        internal Module(Dependencies dependencies) {
            this.dependencies = dependencies;
        }

        public void Factory<T>(Func<DependencyGetter, object> factory) {
            dependencies.Factory<T>(factory);
        }

        public void Single<T>(Func<DependencyGetter, object> factory) {
            dependencies.Single<T>(factory);
        }

        public NamedFactory Named(string name) => new NamedFactory(dependencies, name);

        public class NamedFactory {
            private readonly Dependencies dependencies;
            private readonly string name;

            internal NamedFactory(Dependencies dependencies, string name) {
                this.dependencies = dependencies;
                this.name = name;
            }

            public void Factory<T>(Func<DependencyGetter, object> factory) {
                dependencies.Factory<T>(factory, name);
            }

            public void Single<T>(Func<DependencyGetter, object> factory) {
                dependencies.Single<T>(factory, name);
            }
        }
    }
}