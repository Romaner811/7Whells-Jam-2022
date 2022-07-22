using UnityEngine;


public abstract class FruitResponder : MonoBehaviour
{
    public const string FRUIT_TAG = "Fruit";

    [SerializeReference] Sensor<Fruit> _sensor;

    private void Start()
    {
        _sensor.OnEnter.AddListener(OnFruitEnter);
    }

    protected abstract void OnFruitEnter(Fruit fruit);
}
