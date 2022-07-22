using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    public UnityEvent OnHit;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();

    void Start()
    {
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
        OnHit?.Invoke();
    }

}
