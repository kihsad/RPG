using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SaveSettings : MonoBehaviour
    {
        [SerializeField]
        private Toggle _isMusicOn;
        [SerializeField]
        private Toggle _isSoundOn;
        [SerializeField]
        private Slider _volumeSlider;
        [SerializeField]
        private Dropdown _gameMode;
        private int _volumeOnOff;
        private int _soundsOnOff;
        private int _volumeDuration;
        private int _modeNumber;

        void Start()
        {
            Load();
        }

        void Update()
        {
            if (_isMusicOn.isOn)
            {
                _volumeOnOff = 1;
            }
            else
            {
                _volumeOnOff = 0;
            }

            if (_isSoundOn.isOn)
            {
                _soundsOnOff = 1;
            }
            else
            {
                _soundsOnOff = 0;
            }

            _volumeDuration = (int)_volumeSlider.value;
            _modeNumber = _gameMode.value;
            Save();
        }
        private void Save()
        {
            PlayerPrefs.SetInt("_volumeDuration", _volumeDuration);
            PlayerPrefs.SetInt("_modeNumber", _modeNumber);
            PlayerPrefs.SetInt("_volumeOnOff", _volumeOnOff);
            PlayerPrefs.SetInt("_soundsOnOff", _soundsOnOff);
            PlayerPrefs.Save();
        }
        private void Load()
        {
            if (PlayerPrefs.HasKey("_volumeDuration"))
            {
                _volumeDuration = PlayerPrefs.GetInt("_volumeDuration");
            }
            if (PlayerPrefs.HasKey("_modeNumber"))
            {
                _modeNumber = PlayerPrefs.GetInt("_modeNumber");
            }
            if (PlayerPrefs.HasKey("_volumeOnOff"))
            {
                _volumeOnOff = PlayerPrefs.GetInt("_volumeOnOff");
            }
            if (_volumeOnOff == 1)
            {
                _isMusicOn.isOn = true;
            }
            else
            {
                _isMusicOn.isOn = false;
            }
            if (PlayerPrefs.HasKey("_soundsOnOff"))
            {
                _soundsOnOff = PlayerPrefs.GetInt("_soundsOnOff");
            }
            if (_soundsOnOff == 1)
            {
                _isSoundOn.isOn = true;
            }
            else
            {
                _isSoundOn.isOn = false;
            }

            _volumeSlider.value = _volumeDuration;
            _gameMode.value = _modeNumber;


        }
    }
}