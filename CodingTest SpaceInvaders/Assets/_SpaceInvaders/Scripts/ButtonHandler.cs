using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private InputField nameInput;
    [SerializeField] private GameObject pauseMenu;
    private const string GAME_SCENE_STRING = "GameScene";
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(GAME_SCENE_STRING);
        if(nameInput != null)
        ScoreManager.instance.playerName = nameInput.text.ToString();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        if(pauseMenu != null) pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (pauseMenu != null) pauseMenu.SetActive(false);
    }

}
