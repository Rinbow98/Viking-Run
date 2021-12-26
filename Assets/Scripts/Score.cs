using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    double score;
    Vector3 lastPosition;

    void Start()
    {
        score = 0;
        lastPosition = player.position;
    }

    void Update()
    {
        if (player.position.y > 0f)
            score += (player.position - lastPosition).magnitude;

        lastPosition = player.position;

        scoreText.text = "Score : " + score.ToString("0");
    }
}
