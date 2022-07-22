using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu()]
public class GameManagerSO : ScriptableObject
{
    [SerializeField] int initialHP = 3;

    public int Score { get; private set; }
    public int HP { get; private set; }

    private void OnEnable()
    {
        Score = 0;
        HP = initialHP;
    }

    public void AddScore()
    {
        Score += 10;
        Debug.Log($"Score: {Score}", this);
    }

    public void Damage()
    {
        HP -= 1;
        Debug.Log($"HP: {HP}", this);

        UpdateLife();
    }

    void UpdateLife()
    {
        if (HP < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAMVE OVER");
        Time.timeScale = 0;
    }
}
