using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreUI;
    private int score;

    public void AddScore(int amount)
    {
        score =score + amount;
        scoreUI.text = score.ToString();
        Debug.Log("Score: " + score);
    }
}
