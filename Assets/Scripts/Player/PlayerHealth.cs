using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    GameObject[] healthBars;
    int currentHealthBarIndex;

    int health;

    private void Awake()
    {
        healthBars = GameObject.FindGameObjectWithTag(TagManager.HEALTH_BAR_HOLDER_TAG).GetComponent<HealthBarHolder>().healthBars;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = healthBars.Length;
        currentHealthBarIndex = health - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SubtractHealth()
    {
        healthBars[currentHealthBarIndex].SetActive(false);
        currentHealthBarIndex--;
        health--;
        if (health<=0)
        {
            GameObject.FindGameObjectWithTag(TagManager.GAMEPLAY_CONTROLLER_TAG).GetComponent<GameOverController>().GameOverShowPanel();
            Destroy(gameObject);
        }
    }
    void AddHealth()
    {
        if (health >= healthBars.Length)
        {
            return;
        }
        health++;
        currentHealthBarIndex = health - 1;
        healthBars[currentHealthBarIndex].SetActive(true);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag==TagManager.HEALTH_TAG)
        {
            AddHealth();
            collision.gameObject.SetActive(false);
        }
    }

}
