using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int Value;

    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        if (!Instance)
            Instance = this;    
    }

    public static void Increase()
    {
        Instance.Value++;
        Instance._scoreText.text = Instance.Value.ToString();
    }
}
