using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Current scene name: " + scene.name + " and scene index: " + scene.buildIndex);

        SceneManager.LoadScene(SceneIndexDestination);
    }
}
