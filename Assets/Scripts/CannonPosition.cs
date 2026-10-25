using UnityEngine;

public class CannonPosition : MonoBehaviour
{
    [SerializeField] private float offsetRadius = 0.3f;

    private Camera mainCamera;
    private Transform playerTransform;

    void Start()
    {
        mainCamera = Camera.main;

        playerTransform = transform.parent;
        
    
    }

    void Update()
    {
        if (playerTransform == null || mainCamera == null) return;

        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(mainCamera.transform.position.z);
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        Vector2 direction = ((Vector2)mouseWorldPos - (Vector2)playerTransform.position).normalized;

        Vector3 newPosition = playerTransform.position + (Vector3)(direction * offsetRadius);
        transform.position = newPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
