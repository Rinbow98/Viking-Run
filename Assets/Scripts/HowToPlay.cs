using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    Canvas HowToPlayUI;
    public static bool GameStart = false;

    void Start()
    {
        HowToPlayUI = GetComponent<Canvas>();
        Debug.Log(HowToPlayUI.name);
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
