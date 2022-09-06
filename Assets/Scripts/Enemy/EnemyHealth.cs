using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    bool destroyEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        if (gameObject.tag==TagManager.ENEMY_TAG)
        {
            SoundManager.instance.Play_EnemyDeath_Sound();
        }
        else
        {
            SoundManager.instance.Play_ObstacleDestroy_Sound();
        }
        if (destroyEnemy)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
