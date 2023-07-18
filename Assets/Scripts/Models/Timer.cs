using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float duration = 300f;
    private float timeRemaining;

    public float TimeRemaining { get { return timeRemaining; } }

    public static event Action OnEndGame;

    private void Start()
    {
        timeRemaining = duration;
    }

    private void OnEnable()
    {
        StartGameManager.OnStartTimer += StartTimer;
    }

    private void OnDisable()
    {
        StartGameManager.OnStartTimer -= StartTimer;
    }

    public void StartTimer()
    {
        StartCoroutine(StartTimerCoroutine());
    }

    private IEnumerator StartTimerCoroutine()
    {
        while (timeRemaining >= 1f)
        {
            timeRemaining -= Time.deltaTime;
            yield return null;
        }

        TimeOver();
    }

    private void TimeOver()
    {
        OnEndGame?.Invoke();
    }
}
