using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonController : MonoBehaviour
{
    public Button controlsButton;
    public GameObject ControlsSelection;

    private void Start()
    {
        controlsButton.onClick.AddListener(controlsOption);
    }

    public void controlsOption()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        ControlsSelection.SetActive(true);
    }
}
