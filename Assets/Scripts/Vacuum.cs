using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float lifeTime = 3f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * -1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Virus"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
