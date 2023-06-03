using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
    public List<ResItem> resolutions = new();
    public Toggle fullscreen;
    public GameObject fullTog;
    public int currRes;
    public TextMeshProUGUI restxt;

    void Start()
    {
        fullTog.GetComponent<Toggle>().isOn = Convert.ToBoolean(PlayerPrefs.GetInt("IsFullscreen"));
        currRes = PlayerPrefs.GetInt("Resolution");
        UpdateText();
    }

    public void ApplyGraphics()
    {
        Screen.SetResolution(resolutions[currRes].horizontal, resolutions[currRes].vertical, fullscreen.isOn);
        PlayerPrefs.SetInt("Resolution", currRes);
        PlayerPrefs.SetInt("IsFullscreen", Convert.ToInt32(fullscreen.isOn));
    }

    public void SwitchLeft()
    {
        currRes--;
        if (currRes < 0)
        {
            currRes = 0;
        }
        UpdateText();
    }
    public void SwitchRight()
    {
        currRes++;
        if (currRes > resolutions.Count - 1)
        {
            currRes = resolutions.Count - 1;
        }
        UpdateText();
    }
    public void UpdateText()
    {
        restxt.text = resolutions[currRes].horizontal.ToString() + " x " + resolutions[currRes].vertical.ToString();
    }
}
[System.Serializable]
public class ResItem
{
    public int horizontal;
    public int vertical;
}
