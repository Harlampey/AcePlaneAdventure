using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public static GameAudio Instance;

    [SerializeField] private AudioSource _musicSource, _clickSource;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        bool IsMusicPlaying = PlayerPrefs.GetInt("IsMusicOn") == 1;

        if (PlayerPrefs.HasKey("IsMusicOn"))
        {
            _musicSource.enabled = IsMusicPlaying;
        }
        else
        {
            PlayerPrefs.SetInt("IsMusicOn", 1);
            PlayerPrefs.SetInt("IsSoundOn", 1);
            PlayerPrefs.SetInt("IsVibroOn", 1);
        }
    }

    public static void UpdateMusicSettings()
    {
        bool IsMusicPlaying = PlayerPrefs.GetInt("IsMusicOn") == 1;
        Instance._musicSource.enabled = IsMusicPlaying;
    }

    public static void PlayClickSound()
    {
        if (PlayerPrefs.GetInt("IsSoundOn") == 1)
            Instance._clickSource.Play();
    }
}
