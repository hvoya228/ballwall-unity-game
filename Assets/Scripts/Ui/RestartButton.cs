using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Button restartButton;

    public static event Action<int> OnRestartScene;

    private void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(Restart);
    }

    public void Show()
    {
        restartButton.gameObject.SetActive(true);
        restartButton.transform.DOScale(new Vector3(1, 1, 1), 3f);
    }

    private void Restart()
    {
        OnRestartScene?.Invoke(0);
    }
}
