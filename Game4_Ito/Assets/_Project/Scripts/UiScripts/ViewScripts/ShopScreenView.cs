using _Project.Runtime.Core.UI.Scripts.Manager;
using _Project.Scripts.Keys;
using UnityEngine;

namespace _Project.Scripts.UiScripts.ViewScripts
{
    public class ShopScreenView : MonoBehaviour
    {
        public void BackButton()
        {
            LoadMainMenuScreen();
        }
        
        private async void LoadMainMenuScreen()
        {
            var openScreen = await ScreenManager.Instance.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.MainMenuLayer);
        }
    }
}
