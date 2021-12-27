using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Canvas EndGameUI;

    void Start()
    {
        EndGameUI = GetComponent<Canvas>();
        EndGameUI.enabled = false;
    }

    private void Update()
    {
        if (GameManager.Ended)
        {
            EndGameUI.enabled = true;
        }
        else
        {
            EndGameUI.enabled = false;
        }
    }
}
