﻿using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameCompleteMenuController : MonoBehaviour
{
    public Button nextButton;
    public Button menuButton;

    private void Awake()
    {
        nextButton.onClick.AddListener(NextLevel);
        menuButton.onClick.AddListener(BackToLobby);
    }
    public void LevelComplete()
    {
        gameObject.SetActive(true);
    }
    public void NextLevel()
    {
        Debug.Log("Reloading Scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.Instance.Play(Sounds.ButtonClick);
    }

    public void BackToLobby()
    {
        Debug.Log("Reloading the lobby Scene...");
        SceneManager.LoadScene(0);
        SoundManager.Instance.Play(Sounds.ButtonClick);
    }
}
