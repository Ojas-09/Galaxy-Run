using UnityEngine;
using TMPro;

public class scoreboard : MonoBehaviour
{
    [SerializeField]TMP_Text scoreboardtext;
    int score = 0;

    public void ScoreUpdate(int amount)
    {
        score = score + amount;
        scoreboardtext.text = score.ToString();
    }
}
