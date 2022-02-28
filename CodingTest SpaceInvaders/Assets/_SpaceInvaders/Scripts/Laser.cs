using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    public static event Action<bool> LaserHit;
    public static event Action AlienDestroyed;
    private void Update()
    {
        transform.position += Vector3.up * 5.0f * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(DestructableObjects.alien.ToString()))
        {
            AlienDestroyed.Invoke();
            Destroy(other.gameObject);

            LaserHit.Invoke(true);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag(DestructableObjects.bounds.ToString()))
        {
            LaserHit.Invoke(true);
            Destroy(gameObject);
        }
    }
}
