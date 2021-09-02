using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Image sr;
    public List<Sprite> skins;
    private int _selectedSkin;
    public GameObject playerSkin;

    public void Awake()
    {
        _selectedSkin = PlayerPrefs.GetInt("skin", 0);
        sr.sprite = skins[_selectedSkin];
    }

    public void NextOption()
    {
        _selectedSkin ++;
        if (_selectedSkin == skins.Count)
        {
            _selectedSkin = 0;
        }

        sr.sprite = skins[_selectedSkin];
        SaveSelectedSkin();
    }
    
    public void PreviusOption()
    {
        _selectedSkin --;
        if (_selectedSkin < 0)
        {
            _selectedSkin = skins.Count - 1;
        }

        sr.sprite = skins[_selectedSkin];
        SaveSelectedSkin();
    }

    public void SaveSelectedSkin()
    {
        
        PlayerPrefs.SetInt("skin", _selectedSkin);
    }
}
