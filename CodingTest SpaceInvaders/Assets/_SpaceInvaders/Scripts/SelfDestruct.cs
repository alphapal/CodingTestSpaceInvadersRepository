using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DestructableObjects
{
    alien,
    Player, 
    bounds
};
public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private DestructableObjects otherTagName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTagName.ToString()))
        {
            Destroy(gameObject);
        }
    }
}
