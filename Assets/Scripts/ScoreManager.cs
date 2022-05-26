using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
#if UNITY_WEBGL
    private WebGLSendContractExample smartContract;
#endif

    private void Awake()
    {
#if !UNITY_WEBGL
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
#else
        smartContract = gameObject.GetComponent<WebGLSendContractExample>();
        
#endif
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
#if !UNITY_WEBGL
        sd.scores.Add(score);
#endif
    }

    public void SendScore(Score score)
    {
        gameObject.GetComponent<WebGLSendContractExample>().OnSendContract(score.score, score.name);
    }

    private void OnDestroy()
    {
#if !UNITY_WEBGL
        SaveScore();
#endif
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
        Debug.Log("Saved");
        Debug.Log(json);
    }
}
