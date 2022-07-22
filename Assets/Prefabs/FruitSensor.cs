using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSensor : Sensor<Fruit>
{
    protected override bool TryGetSubject(Collider2D collider, out Fruit subject)
    {
        return collider.attachedRigidbody.TryGetComponent<Fruit>(out subject);
    }
}
