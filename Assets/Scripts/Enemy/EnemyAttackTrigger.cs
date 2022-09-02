using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    EnemyAnimation enemyAnim;

    private void Awake()
    {
        enemyAnim = GetComponentInParent<EnemyAnimation>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag==TagManager.PLAYER_TAG)
        {
            enemyAnim.PlayAttack();
        }
    }

}
