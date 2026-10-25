using UnityEngine;

public class MagicAnimation : MonoBehaviour
{

    private Animator projectileAnimation;
    void Start()
    {
        projectileAnimation = GetComponent<Animator>();

    }
    void Awake()
    {
        projectileAnimation.enabled = true;

        
    }
    void Update()
    {
        
    }
}
