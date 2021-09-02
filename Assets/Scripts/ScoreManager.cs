using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("scores"))
        {
            var json = PlayerPrefs.GetString("scores");
            sd = JsonUtility.FromJson<ScoreData>(json);
            Debug.Log("Loaded");
            Debug.Log(json);    
        }
        else
        {
            sd = new ScoreData();
        }
        
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
        Debug.Log("Saved");
        Debug.Log(json);
    }
}
