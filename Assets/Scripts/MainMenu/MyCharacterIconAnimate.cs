using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MyCharacterIconAnimate : MonoBehaviour
{
    Image sr;
    
    [SerializeField]
    Sprite[] characterIconSrs;

    int srIndex = 0;

    float animateTimer;

    [SerializeField]
    float animateTimerTreshold = 0.5f;

    private void Awake()
    {
        sr=GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > animateTimer)
        {
            srIndex++;
            if (srIndex>= characterIconSrs.Length)
            {
                srIndex = 0;
            }
            sr.sprite = characterIconSrs[srIndex];
            animateTimer=Time.time+ animateTimerTreshold;
        }
    }
}
