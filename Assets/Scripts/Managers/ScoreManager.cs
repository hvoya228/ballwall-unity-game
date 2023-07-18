using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerScoreText blueScoreText;
    [SerializeField] private PlayerScoreText purpleScoreText;
    [SerializeField] private Goal blueGoal;
    [SerializeField] private Goal purpleGoal;
    [SerializeField] private Player bluePlayer;
    [SerializeField] private Player purplePlayer;

    private void OnEnable()
    {
        blueGoal.OnOponentScoreIncrease += IncreasePurpleScore;
        purpleGoal.OnOponentScoreIncrease += IncreaseBlueScore;
    }

    private void OnDisable()
    {
        blueGoal.OnOponentScoreIncrease -= IncreasePurpleScore;
        purpleGoal.OnOponentScoreIncrease -= IncreaseBlueScore;
    }

    private void IncreaseBlueScore()
    {
        IncreaseScore(bluePlayer, blueScoreText);
    }

    private void IncreasePurpleScore()
    {
        IncreaseScore(purplePlayer, purpleScoreText);
    }

    private void IncreaseScore(Player player, PlayerScoreText playerScoreText)
    {
        player.IncreaseScore();
        playerScoreText.ScoreToText(player.Score);
    }
}
