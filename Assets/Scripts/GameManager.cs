using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText; // <-- Add this

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        Score += value;
        Debug.Log("Current Score: " + Score);

        // Update the on-screen score text
        if (scoreText != null)
        {
            scoreText.text = $"Score: {Score}";
        }
    }
}

