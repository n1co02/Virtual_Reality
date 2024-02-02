using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Punktestand: " + score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}

