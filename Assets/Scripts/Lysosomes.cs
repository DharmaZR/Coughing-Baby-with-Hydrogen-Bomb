using UnityEngine;

public class Lysosomes : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float lifeTime = 3f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime*-1);
    }
}
