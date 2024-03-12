using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Runtime.Core.Bundle.Scripts;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    private async Task Awake()
    {
        DontDestroyOnLoad(gameObject);
        //await bundle.LoadScene("GameScene");
    }

    public void PlayButton()
    {
        Debug.Log("çalıştı");
        OnClickPlay();
    }
    
    public async Task OnClickPlay()
    {
        var bundle = BundleModel.Instance;
        bundle = new BundleModel();
        await bundle.LoadScene("GameScene");
    }
    
}
