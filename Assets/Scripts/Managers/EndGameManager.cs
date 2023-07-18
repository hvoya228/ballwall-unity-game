using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private RestartButton restartButton;

    public static event Action OnFallingWalls;

    private void OnEnable()
    {
        Timer.OnEndGame += EndGame;
    }

    private void OnDisable()
    {
        Timer.OnEndGame -= EndGame;
    }

    private void EndGame()
    {
        OnFallingWalls?.Invoke();
        Ball.DeathAll();
        restartButton.Show();
    }
}
