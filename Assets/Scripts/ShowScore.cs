using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        scoreText.text = FindObjectOfType<Score>().GameScore.ToString("0");
    }

}
