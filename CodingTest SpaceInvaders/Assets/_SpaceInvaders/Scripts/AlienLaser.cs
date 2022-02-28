using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienLaser : MonoBehaviour
{
    private const string GAME_OVER_SCENE_STRING = "GameOverScene";
    private void Update()
    {
        transform.position += Vector3.down * 5.0f * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(DestructableObjects.Player.ToString()))
        {
            SceneManager.LoadScene(GAME_OVER_SCENE_STRING);
        }
    }
}
