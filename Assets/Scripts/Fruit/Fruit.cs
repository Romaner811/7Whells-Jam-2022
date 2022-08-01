using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    public UnityEvent OnHit;
    Rigidbody2D rb;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = GetRandomSprite();
    }

    private Sprite GetRandomSprite()
    {
        var random = new System.Random();
        int index = random.Next(sprites.Count);
        return sprites[index];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //calculate bounce angle
            Vector2 normal = collision.GetContact(0).normal;
            Vector2 velocity = rb.velocity;
            print(velocity);
            

            Vector2 u = ((Vector2.Dot(normal, velocity)) / Vector2.Dot(normal , normal)) * normal;
            Vector2 w = velocity - u;
            Vector2 bounceAngle = w - u;

            // print($"u: {u}");
            // print($"w: {w}");
            Vector2 bounce = Vector2.Reflect(velocity, normal);
            // print($"n: {normal}");
            print($"boune angle: {bounce}");
            //apply angle to self
            // rb.velocity = bounce * 10;
            // rb.AddForce(bounce * 10, ForceMode2D.Impulse);
        
        
        }

        OnHit?.Invoke();
    }

    public void Destory()
    {
        Destroy(gameObject);
    }
}
