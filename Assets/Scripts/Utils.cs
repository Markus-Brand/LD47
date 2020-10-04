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
        
        
        public static Quaternion AsZRotation(this Vector2 vector, float offset = 0)
        {
            return Quaternion.Euler(0, 0, 180.0f / Mathf.PI * Mathf.Atan2(vector.y, vector.x) + offset);
        }
        
        
        public static Quaternion AsZRotation(this Vector2Int vector, float offset = 0)
        {
            return Quaternion.Euler(0, 0, 180.0f / Mathf.PI * Mathf.Atan2(vector.y, vector.x) + offset);
        }

    }
}