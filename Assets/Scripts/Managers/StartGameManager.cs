using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Ball ball;
    [SerializeField] private List<MovingWall> movingWalls;
    [SerializeField] private List<PlayerScoreText> playerScoreTexts;

    public static event Action OnStartTimer;
    public static event Action<string> OnShowGameStartMessage;

    private void Start()
    {
        ball.Spawn();

        foreach(var movingWall in movingWalls)
        {
            movingWall.StartMoving();
        }

        StartCoroutine(ShowGameStartMessageCoroutine());
        StartCoroutine(StartTimerCoroutine());
    }

    private IEnumerator ShowGameStartMessageCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        OnShowGameStartMessage?.Invoke("Try to get more score than your oponent");
    }

    private IEnumerator StartTimerCoroutine()
    {
        yield return new WaitForSeconds(7f);
        OnStartTimer?.Invoke();
    }
}
