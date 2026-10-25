using UnityEngine;
using TMPro;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float weaponSpeed = 15f;
    [SerializeField] private float cooldown = 3f;

    private float nextFireTime =0f;
    [SerializeField] private TextMeshProUGUI cooldownText;
    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float timeRemaining = nextFireTime - Time.time;
        if(cooldownText != null){
            if(timeRemaining>0){
                cooldownText.text = "Cooldown: " + timeRemaining.ToString("F1");
            } else {
                cooldownText.text = "Click to fire!";
            }
        }
        if(Input.GetMouseButtonDown(0) && Time.time >= nextFireTime){
            Shoot();
            nextFireTime = Time.time + cooldown;
        }
    }

    void Shoot(){
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(mainCamera.transform.position.z);
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        Vector3 origin = firePoint != null ? firePoint.position : transform.position;

        Vector2 direction = ((Vector2)mouseWorldPos- (Vector2)origin).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.Euler(0,0,angle);

        GameObject bullet = Instantiate(bulletPrefab, origin, bulletRotation);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = direction * weaponSpeed;
    }
}
