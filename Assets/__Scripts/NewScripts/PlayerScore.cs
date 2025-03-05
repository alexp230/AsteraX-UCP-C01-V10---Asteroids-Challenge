using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static int Score = 0;


    public static void IncreasePlayerScore(char astroidType)
    {
        switch (astroidType)
        {
            case 'A': Score += 100; break;
            case 'B': Score += 200; break;
            case 'C': Score += 300; break;
        }

        print($"Score: {Score}");
    }

}
