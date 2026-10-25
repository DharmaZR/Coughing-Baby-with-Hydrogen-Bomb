using TMPro;
using UnityEngine;

public class LittleGuyZoom : MonoBehaviour
{

    public TextMeshProUGUI endText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale+= new Vector3(0.01f, 0.01f, 0.01f) * Time.deltaTime;
        if (transform.localScale.x > 0.12f)
        {
            transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
            endText.gameObject.SetActive(true);
        }
    }
}
