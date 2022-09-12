using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            var obj = FindObjectOfType<T>();

            if (obj == null)
                throw new Exception($"Non Singleton object with type {nameof(T)}");

            _instance = obj;

            return _instance;
        }
    }
}
