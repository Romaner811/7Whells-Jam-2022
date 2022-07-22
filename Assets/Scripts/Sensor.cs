using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        OnEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        OnExit?.Invoke();
    }
}
