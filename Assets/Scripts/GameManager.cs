using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool Ended = false;

    private void Start()
    {

    }

    public void EndGame()
    {
        if (!Ended)
        {
            Ended = true;
            Debug.Log("Gameover");
            Invoke("Restart", 2f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void HowToPlay()
    {
        
    }

    public void EndScreen()
    {

    }

}
