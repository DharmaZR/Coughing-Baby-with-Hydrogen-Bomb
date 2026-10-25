using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PressPlay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private string sceneToLoad;

    void Update(){
        if(Mouse.current.leftButton.wasPressedThisFrame){
            SceneManager.LoadScene(sceneToLoad);

        }
    }
}
