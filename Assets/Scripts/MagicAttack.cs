using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float weaponSpeed = 15f;
    private int currentBulletIndex = 0;

    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            
        }
    }

    void Shoot()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(mainCamera.transform.position.z);
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        Vector3 origin = firePoint != null ? firePoint.position : transform.position;

        Vector2 direction = ((Vector2)mouseWorldPos - (Vector2)origin).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.Euler(0, 0, angle);

        GameObject bullet = Instantiate(bulletPrefab[currentBulletIndex], origin, bulletRotation);
        currentBulletIndex = (currentBulletIndex + 1) % bulletPrefab.Length;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = direction * weaponSpeed;
    }
}
