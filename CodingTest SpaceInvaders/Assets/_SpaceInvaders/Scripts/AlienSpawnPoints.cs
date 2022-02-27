using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienSpawnPoints : MonoBehaviour
{
    [SerializeField] private GameObject alienPrefab;
    [SerializeField] private GameObject alienLaserPrefab;
    [SerializeField] private float laserShootTime = 5f, laserShootRate = 2f;
    [SerializeField] private int rows, cols;
    [SerializeField] private Transform rightBound, leftBound;
    private float alienSpeed = 1.0f;
    private Vector3 alienDirection = Vector3.right;
    private int aliensKilled = 0;
    public static event Action<int> AliensKilled;

    private void OnEnable()
    {
        Laser.AlienDestroyed += AlienDestroyed;
    }
    private void OnDisable()
    {
        Laser.AlienDestroyed -= AlienDestroyed;
    }

    private void Awake()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                Instantiate(alienPrefab, new Vector2(gameObject.transform.position.x + i, gameObject.transform.position.y + j), Quaternion.identity, gameObject.transform);
            }
        }
        InvokeRepeating(nameof(AlienFire), laserShootTime, laserShootRate);
    }
    private void Update()
    {
        gameObject.transform.position += alienDirection * alienSpeed * Time.deltaTime;
        
        foreach(Transform alien in transform)
        {
            if (alienDirection == Vector3.right && alien.position.x >= rightBound.position.x)
            {
                alienDirection = Vector3.left;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
            }
            else if (alienDirection == Vector3.left && alien.position.x <= leftBound.position.x)
            {
                alienDirection = Vector3.right;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
            }
        }
    }

    private void AlienFire()
    {
        Instantiate(alienLaserPrefab, transform.position, Quaternion.identity);
    }

    private void AlienDestroyed()
    {
        aliensKilled++;
        AliensKilled.Invoke(aliensKilled);

        if(aliensKilled >= (rows * cols))
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().name));
        }
    }

}
