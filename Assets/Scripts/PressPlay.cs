using UnityEngine;
using UnityEngine.SceneManagement;

public class PressPlay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private string sceneToLoad;

    private void OnMouseDown(){
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Mouse Clicked");
    }
}
