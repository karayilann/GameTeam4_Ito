using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Runtime.Core.Bundle.Scripts;
using _Project.Runtime.Core.UI.Scripts.Manager;
using _Project.Scripts.Keys;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UiScripts.ViewScripts
{
    public class SettingsScreenView : MonoBehaviour
    {
        public Slider MainMusicSlider;
        public GameObject HowToPlayPanel;
        
        public AudioSource AudioSource;
        public List<AudioClip> GameMusics;
        
        private float _audioSourceVolume;
        private float _sliderValue;

        
        private void Start()
        {
            _audioSourceVolume = AudioSource.volume;
            _sliderValue = MainMusicSlider.value;
            
            // Default ses ayarı
            _audioSourceVolume = .5f;
            _sliderValue = .5f;
        }

        public void OnSliderChanged()
        {
            _audioSourceVolume = _sliderValue;
        }

        public void BackButton()
        {
             LoadMainMenuScreen();
        }
        
        private async void LoadMainMenuScreen()
        {
            var openScreen = await ScreenManager.Instance.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.MainMenuLayer);
        }

        /// <summary>
        /// Settings ekranı içindeki nasıl oynanır butonu scripti
        /// </summary>
        public void HowToPlayButton()
        {
            HowToPlayPanel.SetActive(true);
        }

        /// <summary>
        /// How to play panelini kapama butonu
        /// </summary>
        public void CloseHtpPanel()
        {
            HowToPlayPanel.SetActive(false);
        }
    }
}
