using UnityEngine;

public class MagicWandController : MonoBehaviour
{

    public GameObject player;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer rocketLauncherSpriteRenderer;
    private Animator playerAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        rocketLauncherSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpriteRenderer != null && rocketLauncherSpriteRenderer != null)
        {
            if (playerAnimator.GetBool("SideWalk") == true && playerSpriteRenderer.flipX == false)
            {
                transform.localPosition = new Vector3(-121f, 0f, 0f);
                rocketLauncherSpriteRenderer.flipY = false;
                rocketLauncherSpriteRenderer.flipX = true;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }
            else if (playerAnimator.GetBool("SideWalk") == true && playerSpriteRenderer.flipX == true)
            {
                transform.localPosition = new Vector3(121f, 0f, 0f);
                rocketLauncherSpriteRenderer.flipY = false;
                rocketLauncherSpriteRenderer.flipX = false;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }
            else
            {
                transform.localPosition = new Vector3(-121f, 0f, 0f);
                rocketLauncherSpriteRenderer.flipY = false;
                rocketLauncherSpriteRenderer.flipX = true;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }


        }
    }
}

