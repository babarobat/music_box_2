using Models;
using UnityEngine;

namespace Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 ToVector3(this Vector3Data from)
        {
            return new Vector3(from.X, from.Y, from.Z);
        }
        
        public static Vector3Data ToVector3Data(this Vector3 from)
        {
            return new Vector3Data(from.x, from.y, from.z);
        }
    }
}