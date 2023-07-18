using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class PlayerScoreText : MonoBehaviour
{
    [SerializeField] private ParticleSystem scoreParticleSysytem;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void ScoreToText(int score)
    {
        text.text = score.ToString();
        scoreParticleSysytem.Play();
    }
}
