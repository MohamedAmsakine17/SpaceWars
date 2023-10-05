using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider _healthSlider;
    [SerializeField] Health _health;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI _scoreText;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        _healthSlider.maxValue = _health.GetHealth();
    }

    void Update()
    {
        HealthUI();
        ScoreUI();
    }

    void HealthUI()
    {
        _healthSlider.value = _health.GetHealth();
    }

    void ScoreUI()
    {
        _scoreText.text = _scoreKeeper.GetCurrentScore().ToString("0000000000");
    }

}
