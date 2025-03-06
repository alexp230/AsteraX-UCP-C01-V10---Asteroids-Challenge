using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PlayerScoreText;
    [SerializeField] private TextMeshProUGUI PlayerLivesText;
    [SerializeField] private RawImage EndGameScreen;    

    public void SetPlayerScoreText(int score)
    {
        PlayerScoreText.text = $"Player Score: {score}";
    }
    public void SetPlayerLivesText(int lives)
    {
        if (lives < 0)
        {
            EndGameScreen.gameObject.SetActive(true);
            Invoke(nameof(RestartGame), 3f);
            return;
        }
        PlayerLivesText.text = $"Lives Left: {lives}";
    }
    private void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
