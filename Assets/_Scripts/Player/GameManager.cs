using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; 
    private int score = 0;

    public void Score()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
}
