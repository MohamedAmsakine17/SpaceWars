using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;
    int _currentScore = 0;

    void Awake()
    {
        
    }

    public float GetCurrentScore()
    {
        return _currentScore;
    }

    public void ChangeScore(int addScore)
    {
        _currentScore += addScore;
        Mathf.Clamp(_currentScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        _currentScore = 0;
    }
}
