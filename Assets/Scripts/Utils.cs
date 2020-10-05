using System;
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

        public static Vector2Int Rotate90Clockwise(this Vector2Int direction)
        {
            return new Vector2Int(direction.y, -direction.x);
        }

        public static Vector2Int Rotate90CounterClockwise(this Vector2Int direction)
        {
            return new Vector2Int(-direction.y, direction.x);
        }

        public static Vector2Int MainDirection(this float eulerAnglesZ)
        {
            while (eulerAnglesZ < 0)
            {
                eulerAnglesZ += 360;
            }

            int direction = (int) (Math.Round(eulerAnglesZ / 90)) % 4;

            switch (direction)
            {
                case 0:
                    return Vector2Int.right;
                case 1:
                    return Vector2Int.up;
                case 2:
                    return Vector2Int.left;
                case 3:
                    return Vector2Int.down;
                default:
                    return Vector2Int.zero;
            }
        }
    }
}