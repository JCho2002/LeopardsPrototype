using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PenaltySystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] float _startTime = 15;
    [SerializeField] float _penaltyTime = 5;
    [SerializeField] float _rewardTime = 30;

    [Space]
    [SerializeField] bool _useLives = false;
    [SerializeField] TextMeshProUGUI _livesText;
    [SerializeField] int _startLives = 2;

    private float _timeRemainingSeconds;
    private int _livesRemaining;

    public float TimeRemainingSeconds
    {
        get => _timeRemainingSeconds;
        set
        {
            if (value < 0) EndGame();
            _timeRemainingSeconds = value;
            int m = (int)(value / 60);
            int s = (int)(value % 60);
            _timeText.text = $"{m:00}:{s:00}";
        }
    }
    public int LivesRemaining
    {
        get => _livesRemaining;
        set
        {
            if (value <= 0) EndGame();
            _livesRemaining = value;
            _livesText.text = $"Lives: {_livesRemaining}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TimeRemainingSeconds = _startTime;
        LivesRemaining = _startLives;
    }

    // Update is called once per frame
    void Update()
    {
        TimeRemainingSeconds -= Time.deltaTime;
    }

    public void OnPenalty()
    {
        if (_useLives) LivesRemaining -= 1;
        else TimeRemainingSeconds -= _penaltyTime;
    }

    public void OnReward()
    {
        TimeRemainingSeconds += _rewardTime;
    }

    public void OnHPPickup()
    {
        if (_useLives) LivesRemaining += 1;
    }

    private void EndGame()
    {
        _timeText.text = "Game Over!";
        Destroy(gameObject);
    }
}
