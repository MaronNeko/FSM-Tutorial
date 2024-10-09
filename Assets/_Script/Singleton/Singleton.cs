using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton, will not be marked as DontDestroyOnLoad.
/// https://youtu.be/LFOXge7Ak3E?si=FAJY_9czTp6LqS0Y
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<SCRIPT> : MonoBehaviour where SCRIPT : Component
{
    protected static SCRIPT instance;

    public static SCRIPT Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SCRIPT>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(SCRIPT).Name + " Auto Generated";
                    instance = obj.AddComponent<SCRIPT>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        InitializeSingleton();
    }

    protected virtual void InitializeSingleton()
    {
        if(!Application.isPlaying)
        {
            return;
        }

        if (instance == null)
        {
            instance = this as SCRIPT;
        }
        else
        {
            Destroy(this);
        }
    }
}
