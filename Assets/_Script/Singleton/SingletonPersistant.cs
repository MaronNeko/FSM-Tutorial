using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPersistant<SCRIPT> : MonoBehaviour where SCRIPT : Component
{
    [SerializeField] private bool AutoUnparentOnAwake = true;

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
        if (!Application.isPlaying)
        {
            return;
        }

        if (AutoUnparentOnAwake)
        {
            transform.SetParent(null);
        }

        if (instance == null)
        {
            instance = this as SCRIPT;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
