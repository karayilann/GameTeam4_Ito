using System.Threading.Tasks;
using _Project.Runtime.Core.Bundle.Scripts;
using _Project.Runtime.Core.UI.Scripts.Manager;
using UnityEngine;

namespace _Project.Scripts.Launcher
{
    public class LauncherScript : MonoBehaviour
    {
        private BundleModel bundle;
        private ScreenManager _screenManager;
        private async Task Awake()
        {
            DontDestroyOnLoad(gameObject);
            BundleModel.Instance = new BundleModel();
            bundle =  BundleModel.Instance;
        
            _screenManager = ScreenManager.Instance;

            await LoadMainMenuScreen();
        }
        
        public async Task LoadMainMenuScreen()
        {
            await _screenManager.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.MainMenuLayer);
        }
    }
}
