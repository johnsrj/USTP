using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class LeaderboardManager : MonoBehaviour
{
    public List<Score> scores;

    
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
#if UNITY_WEBGL
            for (int i = 0; i < 10; i++)
            {
                
            }
#else
            for (int i = 0; i < 7; i++)
            {
                string leaderboardNamei = "leaderboardName" + i.ToString();
                string leaderboardScorei = "leaderboardScore" + i.ToString();
                if (PlayerPrefs.HasKey(leaderboardNamei))
                {
                    scores[i].name = PlayerPrefs.GetString(leaderboardNamei);
                    scores[i].score = PlayerPrefs.GetInt(leaderboardScorei);
                    //scores[i].UpdateUI();
                }
                else
                {
                    if (i == 0)
                    {
                        PlayerPrefs.SetString(leaderboardNamei,"BOT");
                        PlayerPrefs.SetInt(leaderboardScorei, UnityEngine.Random.Range(0, 2001));
                    }
                    else
                    {
                        PlayerPrefs.SetString(leaderboardNamei,"BOT");
                        PlayerPrefs.SetInt(leaderboardScorei, UnityEngine.Random.Range(10, PlayerPrefs.GetInt(
                            "leaderboardScore" + (i-1).ToString())));
                    }
                    scores[i].name = PlayerPrefs.GetString(leaderboardNamei);
                    scores[i].score = PlayerPrefs.GetInt(leaderboardScorei);
                    //scores[i].UpdateUI();
                }
            }
#endif
        }
        
    }

    public void UpdateLB()
    {
        for (int i = 0; i < 7; i++)
        {
            Debug.Log("Not implemented");
        }
    }

    public void UpdateLeaderboard(int score, string name)
    {
        /*for (int i = 0; i < 7; i++)
        {
            string leaderboardNamei = "leaderboardName" + i.ToString();
            string leaderboardScorei = "leaderboardScore" + i.ToString();
            if (score > PlayerPrefs.GetInt(leaderboardScorei))
            {
                Score auxScore = new Score(PlayerPrefs.GetInt(leaderboardScorei),
                    PlayerPrefs.GetString(leaderboardNamei));
                Score auxScore2 = auxScore;
                PlayerPrefs.SetInt(leaderboardScorei, score);
                PlayerPrefs.SetString(leaderboardNamei, name);
                for (int j = i+1; j < 7; j++)
                {
                    Debug.Log("Aux score: " + auxScore.score);
                    Debug.Log("Aux score 2: " +auxScore2.score);
                    auxScore = auxScore2;
                    string leaderboardNamej = "leaderboardName" + j.ToString();
                    string leaderboardScorej = "leaderboardScore" + j.ToString();
                    auxScore2.score = PlayerPrefs.GetInt(leaderboardScorej);
                    auxScore2.name = PlayerPrefs.GetString(leaderboardNamej);
                    
                    PlayerPrefs.SetInt(leaderboardScorej, auxScore.score);
                    PlayerPrefs.SetString(leaderboardNamej, auxScore.name);
                    
                }

                return i+1;
            }
        }
        Debug.Log("Leaderboard Not Updated");
        return -1;*/
        List<Score> upperScores = new List<Score>();
        List<Score> lowerScores = new List<Score>();
        int aux = 0;
        for (int i = 0; i < 7; i++)
        {
            string leaderboardNamei = "leaderboardName" + i.ToString();
            string leaderboardScorei = "leaderboardScore" + i.ToString();
            if (score > PlayerPrefs.GetInt(leaderboardScorei))
            {
                upperScores.Add(new Score(score, name));
                aux = i;
                break;
            }
            upperScores.Add(new Score(PlayerPrefs.GetInt(leaderboardScorei),
                PlayerPrefs.GetString(leaderboardNamei)));
            
        }

        for (int i = aux; i < 7; i++)
        {
            string leaderboardNamei = "leaderboardName" + i.ToString();
            string leaderboardScorei = "leaderboardScore" + i.ToString();
            lowerScores.Add(new Score(PlayerPrefs.GetInt(leaderboardScorei),
                PlayerPrefs.GetString(leaderboardNamei)));
        }

        for (int i = 0; i < 7; i++)
        {
            string leaderboardNamei = "leaderboardName" + i.ToString();
            string leaderboardScorei = "leaderboardScore" + i.ToString();
            if (upperScores != null && i < upperScores.Count - 1)
            {
                PlayerPrefs.SetInt(leaderboardScorei, upperScores[i].score);
                PlayerPrefs.SetString(leaderboardNamei, upperScores[i].name);
            }
            else if(lowerScores != null )
            {
                PlayerPrefs.SetInt(leaderboardScorei, lowerScores[i].score);
                PlayerPrefs.SetString(leaderboardNamei, lowerScores[i].name);
            }
        }
    }

}
