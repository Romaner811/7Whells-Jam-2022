using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ninja : FruitResponder
{
    public UnityEvent OnFruit;

    protected override void OnFruitEnter(Fruit item)
    {
        OnFruit?.Invoke();
    }
}
