using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBackground : MonoBehaviour
{
    GameObject[] backgrounds;

    [SerializeField]
    string bgTag;

    float highestXPosition;
    float offsetValue;
    float newXPos;
    Vector3 newPosition;

    private void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag(bgTag);
        offsetValue = backgrounds[0].GetComponent<BoxCollider2D>().bounds.size.x-0.1f;
        highestXPosition= backgrounds[0].transform.position.x;
        for(int i=0;i<backgrounds.Length; i++)
        {
            if (backgrounds[i].transform.position.x > highestXPosition)
            {
                highestXPosition = backgrounds[i].transform.position.x;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag==bgTag)
        {
            newXPos=highestXPosition+offsetValue;
            highestXPosition = newXPos;

            newPosition = collision.transform.position;
            newPosition.x = newXPos;
            collision.transform.position = newPosition;
        }
    }

}
