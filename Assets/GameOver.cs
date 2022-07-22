using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeReference] GameManagerSO manager;

    private void Awake()
    {
        manager.OnGameOVer += () =>
        {
            gameObject.SetActive(true);
        };
    }
}
