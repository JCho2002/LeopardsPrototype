using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float _startTime;

    [SerializeField]
    private float _penaltyTime;

    [SerializeField]
    private float _rewardTime;

    [SerializeField]
    private TextMeshProUGUI _timeUI;

    [SerializeField]
    private TextMeshProUGUI _animalUI;

    [SerializeField]
    private GameObject _gameOverScreen;

    private float _timer;
    private AnimalNames _currentAnimal;

    private void Start()
    {
        _timer = _startTime;
        _gameOverScreen.SetActive(false);
        NewAnimal();

        PlayerAnimalSelect player = FindObjectOfType<PlayerAnimalSelect>();
        player.AnimalChosen += Player_OnAnimalChosen;
    }

    private void Player_OnAnimalChosen(object sender, AnimalEventArgs e)
    {
        if(e.Name == _currentAnimal)
        {
            RightAnimalChosen();
        }
        else
        {
            WrongAnimalChosen();
        }

        NewAnimal();
    }

    private void WrongAnimalChosen()
    {
        _timer -= _penaltyTime;
    }

    private void RightAnimalChosen()
    {
        _timer += _rewardTime;
    }

    private void NewAnimal()
    {
        int animalCount = Enum.GetNames(typeof(AnimalNames)).Length;
        int newAnimal = UnityEngine.Random.Range(0, animalCount);
        _currentAnimal = (AnimalNames)newAnimal;
        UpdateAnimalText();
    }

    private void UpdateAnimalText()
    {
        _animalUI.text = _currentAnimal.ToString();
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        UpdateTimeUI();
        CheckGameOver();

    }

    private void CheckGameOver()
    {
        if(_timer <= 0)
        {
            _gameOverScreen.SetActive(true);
        }
    }

    private void UpdateTimeUI()
    {
        int seconds = (int)(_timer % 60);
        int minutes = (int)(_timer / 60);

        _timeUI.text = $"{minutes:00}:{seconds:00}";
    }
}
