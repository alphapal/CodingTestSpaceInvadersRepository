using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float shipSpeed = 5f;
    [SerializeField] Laser laserPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    private bool laserHit = true;

    private void OnEnable()
    {
        Laser.LaserHit += (hit) => LaserHit(hit);
    }

    private void OnDisable()
    {
        Laser.LaserHit -= (hit) => LaserHit(hit);
    }
    private void LaserHit(bool hit)
    {
        laserHit = hit;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-shipSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(shipSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (laserHit)
        {
            Instantiate(laserPrefab, bulletSpawnPoint.position, Quaternion.identity);
            laserHit = false;
        }
    }
}
