using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int score = 0;
    public int Score { get { return score; } }

    public void IncreaseScore()
    {
        score++;
    }
}
