using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketSound : MonoBehaviour
{
    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Fruit"))
        {   
            source.Play();
        }
    }
}
