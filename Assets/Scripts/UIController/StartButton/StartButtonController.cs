using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    public Button startButton;
    public Button optionButton;
    public Button backButton;

    public GameObject LevelSelection;
    public GameObject OptionSelection;

    public GameObject menuBackground;

    private void Start()
    {
        startButton.onClick.AddListener(PlayGame);
        optionButton.onClick.AddListener(AnyOptionSelection);
        backButton.onClick.AddListener(backButtonSound);
    }

    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        menuBackground.SetActive(false);
        LevelSelection.SetActive(true);
    }

    public void AnyOptionSelection()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);        
        OptionSelection.SetActive(true);
    }

    private void backButtonSound()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
    }
}
