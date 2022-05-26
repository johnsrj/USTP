using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int _score;
    public TextMeshProUGUI ScoreText;
    public GameObject[] Hearts;
    private int health;

    public GameObject gameOverScreen;
    public TextMeshProUGUI totalScore;
    public GameObject HI;
    private AudioManager audio;

    public GameObject pauseMenu;

    public GameObject spawners;

    public bool isPaused;
    public bool gameisOver = false;

    #region Getters&Setters

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    #endregion

    

    public void AddScore(int value)
    {
        Score += value;
    }

    private void Awake()
    {
        Score = 0;
        health = Hearts.Length;
        audio = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        ScoreText.text = Score.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void LoseHeart()
    {
        if (health > 1)
        {
            audio.Play("LoseLife");
            Hearts[health - 1].SetActive(false);
            health--;
        }
        else if(! gameisOver)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        audio.Play("LoseLife");
        gameisOver = true;
        Destroy(FindObjectOfType<Player>());
        Destroy(spawners);
        totalScore.text = _score.ToString();
        gameOverScreen.SetActive(true);
        if (_score <= 0) return;
        FindObjectOfType<ScoreManager>().AddScore(new Score(_score, PlayerPrefs.GetString("PlayerName")));
        FindObjectOfType<ScoreManager>().SaveScore();

    }

    public void OnClickSendScore()
    {
        FindObjectOfType<ScoreManager>().SendScore(new Score(_score, PlayerPrefs.GetString("PlayerName")));
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay");
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

}
