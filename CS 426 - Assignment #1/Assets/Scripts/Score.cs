// add score manager
using UnityEngine;
using UnityEngine.UI;

// access the Text Mesh Pro namespace
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public int maxScore = 5;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // EDIT: the score text now refers to the objective
        scoreText.text = "Chao Fed: " + score + "/5";
    }

    //we will call this method from our target script
    // whenever the player collides or shoots a target a point will be added
    public void AddPoint()
    {
        score++;

        if (score != maxScore)
            // EDIT: the score updates based on completing the objective
            scoreText.text = "Chao Fed: " + score + "/5";
        else
            scoreText.text = "You won!";
    }
}