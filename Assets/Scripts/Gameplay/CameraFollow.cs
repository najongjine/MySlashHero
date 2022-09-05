using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerPos;

    [SerializeField]
    float offsetX = -6f;

    Vector3 tempPos;

    private void Awake()
    {
        //FindPlayerReference();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }
    public void FindPlayerReference()
    {
        playerPos = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }
    void FollowPlayer()
    {
        if (!playerPos)
        {
            return;
        }
        tempPos = transform.position;
        tempPos.x=playerPos.position.x-offsetX;
        transform.position = tempPos;
    }

}
