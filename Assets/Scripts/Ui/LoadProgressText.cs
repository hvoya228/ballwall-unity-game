using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LoadProgressText : MonoBehaviour
{
    [SerializeField] private SceneLoadManager sceneLoadManager;
    private Text loadProgressText;

    private void Start()
    {
        loadProgressText = GetComponent<Text>();
        loadProgressText.gameObject.SetActive(false);
    }

    private void Update()
    {
        loadProgressText.text = sceneLoadManager.LoadProgress.ToString() + "%";
    }

    private void OnEnable()
    {
        SceneLoadManager.OnShowReloadProgress += Show;
    }

    private void OnDisable()
    {
        SceneLoadManager.OnShowReloadProgress -= Show;
    }

    private void Show()
    {
        loadProgressText.gameObject.SetActive(true);
    }
}
