using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float shipSpeed = 5f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-shipSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(shipSpeed * Time.deltaTime, 0, 0);
        }
    }
}
