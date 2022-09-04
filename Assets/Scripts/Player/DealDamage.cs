using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]
    bool deactivateGameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagManager.PLAYER_TAG)
        {
            if (deactivateGameObject)
            {
                Debug.Log($"## player collided");
                collision.gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.tag == TagManager.ENEMY_TAG || collision.gameObject.tag == TagManager.OBSTACLE_TAG)
        {
            Debug.Log($"## enemy collided");
            collision.gameObject.SetActive(false);
        }
    }
}
