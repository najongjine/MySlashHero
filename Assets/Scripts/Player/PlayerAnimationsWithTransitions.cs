using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsWithTransitions : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    GameObject damageCollider;

    private void Awake()
    {
        anim= GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayFromJumpToRunning(bool running)
    {
        anim.SetBool(TagManager.RUNNING_ANIMATION_PARAMETER,running);
    }
    public void PlayJump(float velY)
    {
        anim.SetFloat(TagManager.JUMP_ANIMATION_PARAMETER, velY);
    }
    public void PlayDoubleJump()
    {
        anim.SetTrigger(TagManager.DOUBLE_JUMP_ANIMATION_PARAMETER);
    }
    public void PlayAttack()
    {
        anim.SetTrigger(TagManager.ATTACK_ANIMATION_PARAMETER);
    }
    public void PlayJumpAttack()
    {
        anim.SetTrigger(TagManager.JUMP_ATTACK_ANIMATION_PARAMETER);
    }
    public void ActivateDamageDetector()
    {
        damageCollider.SetActive(true);
    }
    public void DeactivateDamageDetector()
    {
        damageCollider.SetActive(false);
    }

}
