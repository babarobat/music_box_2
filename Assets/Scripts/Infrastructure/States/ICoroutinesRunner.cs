using System.Collections;
using UnityEngine;

namespace Infrastructure.States
{
    public interface ICoroutinesRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}