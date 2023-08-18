using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Toggle _musicToggle, _soundToggle, _vibrationToggle;

    private void Start()
    {
        ShowCurrentSettings();
    }
    private void ShowCurrentSettings()
    {
        _musicToggle.isOn = PlayerPrefs.GetInt("IsMusicOn") == 1;
        _soundToggle.isOn = PlayerPrefs.GetInt("IsSoundOn") == 1;
        _vibrationToggle.isOn = PlayerPrefs.GetInt("IsVibroOn") == 1;
    }

    public void ToggleMusic(bool isOn)
    {
        int value = isOn ? 1 : 0;
        PlayerPrefs.SetInt("IsMusicOn", value);

        GameAudio.UpdateMusicSettings();
        GameAudio.PlayClickSound();
    }
    public void ToggleSound(bool isOn)
    {
        int value = isOn ? 1 : 0;
        PlayerPrefs.SetInt("IsSoundOn", value);

        GameAudio.PlayClickSound();
    }
    public void ToggleVibro(bool isOn)
    {
        int value = isOn ? 1 : 0;
        PlayerPrefs.SetInt("IsVibroOn", value);

        GameAudio.PlayClickSound();
    }
}
