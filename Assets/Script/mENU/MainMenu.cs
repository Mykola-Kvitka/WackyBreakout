using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject audioManager;
    private void Start()
    {
        AudioManager.Play(AudioClipName.MainMenuTheam);
    }
    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("Game");
    }
    public void HandleHelpButtonOnClickEvent()
    {
        SceneManager.LoadScene("Help");
    }  

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
