using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Runtime.Core.Bundle.Scripts;
using _Project.Runtime.Core.UI.Scripts.Manager;
using _Project.Scripts.Keys;
using UnityEngine;

public class MainMenuView : MonoBehaviour
{
    private BundleModel bundle;
    private ScreenManager _screenManager;
    
    private async Task Awake()
    {
        DontDestroyOnLoad(gameObject);
        BundleModel.Instance = new BundleModel();
        bundle =  BundleModel.Instance;
        
        _screenManager = ScreenManager.Instance;
    }

    #region The codes assigned to the buttons on the scene.
    
    public async void PlayButton()
    {
       await OnClickPlay();
    }

    public async void SettingsButton()
    {
        await SettingsScreen();
    }
    
    public async void CreditsButton()
    {
        await CreditsScreen();
    }

    public async void ShopButton()
    {
        await ShopScreen();
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }

    #endregion

    #region The codes accessed through ScreenManager.

    private async Task OnClickPlay()
    {
        await bundle.LoadScene("GameScene");
    }
    
    private async Task SettingsScreen()
    {
        var openScreen = _screenManager.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayerKeys.MainMenuLayer);
    }

    private async Task CreditsScreen()
    {
        var openScreen = _screenManager.OpenScreen(ScreenKeys.CreditsScreen, ScreenLayerKeys.MainMenuLayer);
    }

    private async Task ShopScreen()
    {
        var openScreen = _screenManager.OpenScreen(ScreenKeys.ShopScreen,ScreenLayerKeys.MainMenuLayer);
    }

    #endregion   
}
