using UnityEngine;

public class scoreboard : MonoBehaviour
{
    int score = 0;

    public void ScoreUpdate(int amount)
    {
        score =+ amount;
        Debug.Log(score);
    }
}
