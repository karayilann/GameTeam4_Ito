using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Runtime.Core.Bundle.Scripts;
using _Project.Runtime.Core.UI.Scripts.Manager;
using UnityEngine;

public class MainMenuView : MonoBehaviour
{
    private BundleModel bundle;
    public Transform Parent;
    private async Task Awake()
    {
        DontDestroyOnLoad(gameObject);
        bundle = BundleModel.Instance;
        bundle = new BundleModel();
        
    }

    public void PlayButton()
    {
        OnClickPlay();
    }

    public void SettingsButton()
    {
        //SettingsScreen();
        bundle.LoadPrefab("SettingsScreen", Parent);
    }
    
    public async Task OnClickPlay()
    {
        await bundle.LoadScene("GameScene");
    }

    public async Task SettingsScreen()
    {
        var screenManager = ScreenManager.Instance;
        var openScreen = screenManager.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayerKeys.SettingsLayer);
        Debug.Log("Async method çalıştı");
    }
    
}
