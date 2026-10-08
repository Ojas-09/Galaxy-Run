using System;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject destoryedVFX;
    [SerializeField] int hitpoints = 3;
    [SerializeField] int scorepower = 10;
    scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindAnyObjectByType<scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        hitpoint();
    }

    private void hitpoint()
    {
        hitpoints--;

        if (hitpoints <= 0)
        {
            scoreboard.ScoreUpdate(scorepower);
            Instantiate(destoryedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
