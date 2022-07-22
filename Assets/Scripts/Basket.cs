using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Basket : MonoBehaviour
{
    public const string FRUIT_TAG = "Fruit";

    [SerializeReference] Sensor _body;

    [SerializeField] int _visualCapacity;

    public UnityEvent OnScore;

    Queue<Fruit> _inside;

    private void Awake()
    {
        _inside = new Queue<Fruit>(_visualCapacity * 2);
    }

    private void Start()
    {
        _body.OnEnter.AddListener(OnEnterBody);
    }

    private void OnEnterBody(Collider2D collider)
    {
        if (collider.TryGetComponent<Fruit>(out var item) == false) return;

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
