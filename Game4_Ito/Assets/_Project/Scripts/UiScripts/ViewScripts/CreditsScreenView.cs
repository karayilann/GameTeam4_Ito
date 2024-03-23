using _Project.Runtime.Core.Bundle.Scripts;
using _Project.Runtime.Core.UI.Scripts.Manager;
using UnityEngine;

namespace _Project.Scripts.UiScripts.ViewScripts
{
    public class CreditsScreenView : MonoBehaviour
    {
        public Transform MainMenuLayer;
        
        public async void OnClickBackButton()
        {
            //await ScreenManager.Instance.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.MainMenuLayer);
            await BundleModel.Instance.LoadPrefab("MainMenuScreen", MainMenuLayer);
        }
    }
}
