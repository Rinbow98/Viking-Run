using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    Vector3 lastPosition;

    public float GameScore { get; private set; }

    void Start()
    {
        GameScore = 0;
        lastPosition = player.position;
    }

    void Update()
    {
        if (player.position.y > 0f)
            GameScore += (player.position - lastPosition).magnitude;

        lastPosition = player.position;

        scoreText.text = "Score : " + GameScore.ToString("0");
    }

    public void AddScore(float score)
    {
        GameScore += score;
    }
}
