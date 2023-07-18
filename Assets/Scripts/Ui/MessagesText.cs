using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MessagesText : MonoBehaviour
{
    private Text messageText;

    private void Awake()
    {
        messageText = GetComponent<Text>();
        messageText.text = "";
    }

    private void OnEnable()
    {
        StartGameManager.OnShowGameStartMessage += ShowMessage;
    }

    private void OnDisable()
    {
        StartGameManager.OnShowGameStartMessage -= ShowMessage;
    }

    private void ShowMessage(string message)
    {
        StartCoroutine(ShowMessageCoroutine(message));
    }

    private IEnumerator ShowMessageCoroutine(string message)
    {
        messageText.text = message;
        messageText.DOFade(1f, 2f);
        yield return new WaitForSeconds(4f);
        messageText.DOFade(0f, 2f);
    }
}
