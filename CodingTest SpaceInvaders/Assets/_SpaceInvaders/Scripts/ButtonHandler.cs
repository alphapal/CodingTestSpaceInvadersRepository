using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private const string GAME_SCENE_STRING = "GameScene";
    public void StartButton()
    {
        SceneManager.LoadScene(GAME_SCENE_STRING);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
