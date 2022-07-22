using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClub : MonoBehaviour
{
    [SerializeField] GameObject club;
    [SerializeField] GameObject grabPos;
    GameObject clubGrabPos;

    void Start()
    {
        
    }
    void OnMouseOver()
    {
        grabPos.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // club.transform.position = (Vector2) grabPos.transform.position - new Vector2(0,3);
    }
}
