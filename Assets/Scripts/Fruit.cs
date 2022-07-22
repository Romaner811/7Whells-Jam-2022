using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    public UnityEvent OnHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHit?.Invoke();
    }
}
