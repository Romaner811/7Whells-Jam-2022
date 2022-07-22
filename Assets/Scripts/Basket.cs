using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Basket : FruitResponder
{
    [SerializeField] int _visualCapacity = 5;

    public UnityEvent OnScore;

    Queue<Fruit> _inside;

    private void Awake()
    {
        _inside = new Queue<Fruit>(_visualCapacity * 2);
    }

    protected override void OnFruitEnter(Fruit item)
    {
        _inside.Enqueue(item);
        item.transform.SetParent(transform);

        OnScore?.Invoke();

        DestroyOverflow();
    }

    public void DestroyOverflow()
    {
        while (_inside.Count > _visualCapacity)
        {
            Fruit item = _inside.Dequeue();
            item.gameObject.SetActive(false);
            Destroy(item);
        }
    }
}
