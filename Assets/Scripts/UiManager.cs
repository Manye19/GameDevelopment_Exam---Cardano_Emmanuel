using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class UiManager : MonoBehaviour
{
    private static UiManager _instance;
    public static UiManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UiManager>();
            }

            return _instance;
        }
    }

    public GameObject menuPanel;
    public Button disconnectButton;
    public Button quitButton;

    private void Awake()
    {
        _instance = this;
    }
}
