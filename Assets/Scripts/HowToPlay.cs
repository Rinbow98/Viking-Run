using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    Canvas HowToPlayUI;
    public static bool GameStart;

    void Start()
    {
        HowToPlayUI = GetComponent<Canvas>();
        GameStart = false;
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            GameStart = true;
            HowToPlayUI.enabled = false;
        }
    }
}
