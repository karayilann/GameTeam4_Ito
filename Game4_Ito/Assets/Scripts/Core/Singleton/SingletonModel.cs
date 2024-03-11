using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonModel<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
}


