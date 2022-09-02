using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    GameObject damageCollider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAttack()
    {
        anim.SetTrigger(TagManager.ATTACK_TRIGGER_PARAMETER);
    }
    public void PlayDeath()
    {
        anim.SetBool(TagManager.DEATH_ANIMATION_PARAMETER,true);
    }
    void ActivateDamageCollider()
    {
        damageCollider.SetActive(true);
    }
    void DeactivateDamageCollider()
    {
        damageCollider.SetActive(false);
    }

}
