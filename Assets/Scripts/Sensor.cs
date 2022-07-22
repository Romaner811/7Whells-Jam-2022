using UnityEngine;
using UnityEngine.Events;

public class Sensor : Sensor<Collider2D>
{
    protected override bool TryGetSubject(Collider2D collider, out Collider2D subject)
    {
        subject = collider;
        return true;
    }
}

public abstract class Sensor<T> : MonoBehaviour
{
    public UnityEvent<T> OnEnter;
    public UnityEvent<T> OnExit;

    protected abstract bool TryGetSubject(Collider2D collider, out T subject);

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (TryGetSubject(collider, out var subject))
        {
            OnEnter?.Invoke(subject);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (TryGetSubject(collider, out var subject))
        {
            OnExit?.Invoke(subject);
        }
    }
}
