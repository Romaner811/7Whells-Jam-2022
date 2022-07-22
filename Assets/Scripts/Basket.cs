using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Basket : MonoBehaviour
{
    public const string FRUIT_TAG = "Fruit";

    [SerializeReference] Sensor _entrance;
    [SerializeReference] Sensor _body;

    public UnityEvent OnScore;

    List<Fruit>

    private void Start()
    {
        
    }

    private void OnEnter()
    {

    }

    private void OnEnterBody()
    {

    }
}
