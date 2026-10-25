using UnityEngine;

public class Cholestrol : MonoBehaviour
{
    public float speed = 2f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0f;
            direction.Normalize();

            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
