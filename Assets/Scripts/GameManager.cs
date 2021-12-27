using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool Ended;

    void Start()
    {
        Ended = false;
    }

    void Update()
    {
        if (Ended && Input.anyKey)
        {
            Restart();
        }
    }

    public void EndGame()
    {
        if (!Ended)
        {
            Ended = true;
            Time.timeScale = 0f;
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
    }

}
