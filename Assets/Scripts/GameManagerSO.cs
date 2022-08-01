using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu()]
public class GameManagerSO : ScriptableObject
{
    [SerializeField] int initialHP = 3;

    public int Score { get; private set; }
    public int HP { get; private set; }

    public System.Action OnGameOVer;

    private void OnEnable()
    {
        Score = 0;
        HP = initialHP;
    }

    public void AddScore()
    {
        Score += 10;
    }

    public void Damage()
    {
        HP -= 1;

        UpdateLife();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void UpdateLife()
    {
        if (HP <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        OnGameOVer?.Invoke();
        Time.timeScale = 0;
    }
}
