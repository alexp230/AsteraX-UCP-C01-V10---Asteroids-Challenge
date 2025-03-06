using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    public UnityEvent<int> ScoreChange;

    private int Score = 0;

    public void IncreasePlayerScore(char astroidType)
    {
        switch (astroidType)
        {
            case 'A': Score += 100; break;
            case 'B': Score += 200; break;
            case 'C': Score += 300; break;
        }

        print($"Score: {Score}");
        ScoreChange?.Invoke(Score);
    }

}
