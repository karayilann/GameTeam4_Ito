using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Runtime.Core.Bundle.Scripts;
using _Project.Runtime.Core.UI.Scripts.Manager;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    private BundleModel bundle;
    private async Task Awake()
    {
        DontDestroyOnLoad(gameObject);
        //var screenManager = ScreenManager.Instance;
        //screenManager.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.MainMenuLayer);
        //Debug.Log("Çalıştı");
    }
    
    
}
