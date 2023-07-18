using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using DG.Tweening;
using System.Net;
using System;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer transitionPanel;

    private float loadProgress = 0f;
    public float LoadProgress { get { return loadProgress; } }

    public static event Action OnShowReloadProgress;

    private void OnEnable()
    {
        RestartButton.OnRestartScene += LoadScene;
    }

    private void OnDisable()
    {
        RestartButton.OnRestartScene -= LoadScene;
    }

    private void LoadScene(int sceneNumber)
    {
        OnShowReloadProgress?.Invoke();
        StartCoroutine(LoadSceneAsync(sceneNumber));
    }

    private IEnumerator LoadSceneAsync(int sceneNumber)
    {
        DOTweenModuleSprite.DOFade(transitionPanel, 1f, 2f);

        yield return new WaitForSeconds(2f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNumber);

        while (!asyncLoad.isDone)
        {
            loadProgress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            Debug.Log("Loading progress: " + (loadProgress * 100f) + "%");

            yield return null;
        }
    }
}
