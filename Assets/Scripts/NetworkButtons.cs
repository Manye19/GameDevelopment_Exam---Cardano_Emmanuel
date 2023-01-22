using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkButtons: MonoBehaviour
{

    public void OnHostButtonClick()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(Constants.MAIN_GAME_SCENE, LoadSceneMode.Single);
    }
    public void OnStartClientButtonClick()
    {
        NetworkManager.Singleton.StartClient();
    }
    public void OnDisconnectButtonClick()
    {
        NetworkManager.Singleton.DisconnectClient(NetworkManager.Singleton.LocalClientId);
        //NetworkManager.Singleton.SceneManager.LoadScene(Constants.TITLE_GAME_SCENE, LoadSceneMode.Single);
    }
    public void OnQuitButtonClick()
    {
        Debug.Log("Application Quit!");
        Application.Quit();
    }
}
