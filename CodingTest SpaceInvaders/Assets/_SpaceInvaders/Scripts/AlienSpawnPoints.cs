using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnPoints : MonoBehaviour
{
    [SerializeField] private GameObject alienPrefab;
    [SerializeField] private int rows, cols;
    [SerializeField] private Transform rightBound, leftBound;
    private float alienSpeed = 1.0f;
    private Vector3 alienDirection = Vector3.right;

    private void Awake()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                Instantiate(alienPrefab, new Vector2(gameObject.transform.position.x + i, gameObject.transform.position.y + j), Quaternion.identity, gameObject.transform);
            }
        }
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
}
