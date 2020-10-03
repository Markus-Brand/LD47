using UnityEngine;

namespace DefaultNamespace
{
    public static class Utils
    {
        public static bool HasComponent<T>(this GameObject obj, out T result) where T : Component
        {
            result = obj.GetComponent<T>();
            return result != null;
        }

        public static bool HasComponent<T>(this GameObject obj) where T : Component
        {
            var result = obj.GetComponent<T>();
            return result != null;
        }

    }
}