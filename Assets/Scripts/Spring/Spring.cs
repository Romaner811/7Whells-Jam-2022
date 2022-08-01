using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
     [SerializeField] float leanAngle;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, leanAngle);
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 pos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = pos;

        if(Input.GetMouseButtonDown(0))
        {
            leanAngle *= -1;
        }
        
        transform.rotation = Quaternion.Euler(0, 0, leanAngle);
    }
}
