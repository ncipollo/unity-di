using Unity.Entities;

namespace UnityDI {
    public static class ComponentSystemExt {
        public static void Get<T>(this ComponentSystemBase system, string name = "") =>
            Injector.Shared.Get<T>(name);

        public static void Inject<T>(this ComponentSystemBase system, string name = "") =>
            Injector.Shared.Inject<T>(name);
    }
}