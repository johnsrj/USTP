using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainMenuController : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject leaderboardPanel;
    public GameObject settingsPanel;
    public InputField name;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            name.text = PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            var nameTemp = GenerateRandomName();
            PlayerPrefs.SetString("PlayerName", nameTemp);
            name.text = nameTemp;
        }
    }

    private string GenerateRandomName()
    {
        var adjective = new List<string>()
        {
            "Happy", "Sad", "Angry", "Curious", "Active", "Bold", "Energetic",
            "Vigorous", "Lazy", "Adamant", "Quick", "Cranky", "Smug", "Serene",
            "Bashful", "Tranquil", "Mature", "Wise"
        };
        var animal = new List<string>()
        {
            "Fox", "Owl", "Wolf", "Dog", "Cat", "Rabbit", "Frog", "Lion", "Bat",
            "Zebra", "Panther", "Bear", "Gecko", "Giraffe", "Snake", "Monkey",
            "Turtle", "Bird", "Falcon", "Shark", "Fish", "Eagle", "Horse"
        };

        var nameTemp = adjective[Random.Range(0, adjective.Count)] +
                       animal[Random.Range(0, animal.Count)];
        return nameTemp;
    }

    public void RollTheDie()
    {
        var nameTemp = GenerateRandomName();
        name.text = nameTemp;
    }

    public void SubmitName()
    {
        if (name.text == "")
        {
            var nameTemp = GenerateRandomName();
            name.text = nameTemp;
            PlayerPrefs.SetString("PlayerName", nameTemp);
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", name.text);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ToggleControls()
    {
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }

    public void ToggleLeaderboard()
    {
        leaderboardPanel.SetActive(!leaderboardPanel.activeSelf);
    }

    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}
