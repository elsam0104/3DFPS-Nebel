using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class UIMgr : MonoBehaviour
{

    public Button startButton;
    public Button optionButton;
    public Button shopButton;

    private UnityAction action;

    void Start()
    {
        action = () => OnStartClick();
        startButton.onClick.AddListener(action);

        optionButton.onClick.AddListener(delegate { onButtonClick(optionButton.name); });
    }

    void OnStartClick()
    {
        SceneManager.LoadScene("Game");
    }
    void onButtonClick(string str)
    {
        Debug.Log($"Click {str}!");
    }
}
