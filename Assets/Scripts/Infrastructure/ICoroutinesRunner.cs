using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public interface ICoroutinesRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}