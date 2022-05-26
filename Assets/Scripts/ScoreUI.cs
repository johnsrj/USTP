using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;
    public void Start()
    {
#if UNITY_WEBGL
        for (int i = 0; i < 10; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = "#" + (i + 1).ToString();
            row.name.text = FindObjectOfType<WebGLSendContractExample>().OnCallContract(i).Result.name;
            row.score.text = FindObjectOfType<WebGLSendContractExample>().OnCallContract(i).Result.score.ToString();
        }
#else
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < (scores.Length > 10 ? 10 : scores.Length); i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = "#" + (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
#endif
    }
    
}
