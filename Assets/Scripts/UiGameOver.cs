using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiGameOver : MonoBehaviour
{
    static UiGameOver instance;

    [SerializeField] TextMeshProUGUI _scoreText;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        _scoreText.text = "YOU SCORED \n" + _scoreKeeper.GetCurrentScore();
    }

    void Update()
    {

    }
}
