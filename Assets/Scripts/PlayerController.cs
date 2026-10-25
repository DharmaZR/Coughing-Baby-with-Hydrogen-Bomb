using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputAction moveAction;
    public float moveSpeed = 1f;

    private Rigidbody2D rb;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public GameObject weapon;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction.Enable();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        // Use moveInput to control the player's movement
        transform.Translate(moveInput * Time.deltaTime * moveSpeed);
        if (moveInput.x != 0)
        {
            animator.SetBool("SideWalk", true);
        }
        else
        {
            animator.SetBool("SideWalk", false);
        }
        if (moveInput.x == 1)
        {
            spriteRenderer.flipX = true;
        }
        if(moveInput.x==-1)
        {
            spriteRenderer.flipX = false;
        }

        if (moveInput.y==1)
        {
            animator.SetBool("UpWalk", true);
        }
        else
        {
            animator.SetBool("UpWalk", false);
        }
        if(moveInput.y == -1)
        {
            animator.SetBool("DownWalk", true);
        }
        else
        {
            animator.SetBool("DownWalk", false);
        }   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animator.GetBool("DownWalk") == true)
            {
                Instantiate(weapon, transform.position, Quaternion.Euler(0, 0, 90));
            }else if (animator.GetBool("UpWalk") == true)
            {
                Instantiate(weapon, transform.position, Quaternion.Euler(0, 0, -90));
            }
            else if (animator.GetBool("SideWalk") == true && spriteRenderer.flipX == false)
            {
                Instantiate(weapon, transform.position, Quaternion.Euler(0, 0, 180));
            }
            else if (animator.GetBool("SideWalk") == true && spriteRenderer.flipX == true)
            {
                Instantiate(weapon, transform.position, Quaternion.Euler(0, 0, 0));
            }
            else
                Instantiate(weapon, transform.position, Quaternion.identity);
        }
    }
}
