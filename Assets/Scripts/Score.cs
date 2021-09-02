using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Score
{
    public int score;
    public string name;

    public Score(int score, string name)
    {
        this.score = score;
        this.name = name;
    }
}

    
