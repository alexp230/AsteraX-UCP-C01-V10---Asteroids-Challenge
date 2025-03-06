using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class UITracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PlayerScoreText;
    [SerializeField] private TextMeshProUGUI PlayerLivesText;
    
    
    public void SetPlayerScoreText(int score)
    {
        PlayerScoreText.text = $"Player Score: {score}";
    }
    public void SetPlayerLivesText(int lives)
    {
        PlayerLivesText.text = $"Lives Left: {lives}";
    }
}
