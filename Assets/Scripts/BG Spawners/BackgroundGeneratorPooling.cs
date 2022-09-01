using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneratorPooling : MonoBehaviour
{
    [SerializeField]
    GameObject groundPrefab,treePrefab;

    int groundsToSpawn = 10,treesToSpawn=5;

    List<GameObject> groundPool = new List<GameObject>();
    List<GameObject> treePool = new List<GameObject>();

    [SerializeField]
    float ground_Y_Pos = -6f, tree_Y_Pos = -0.18f;
    [SerializeField]
    float ground_X_Distance = 17.85f, tree_X_Distance = 41f;

    float lastGroundXPos, lastTreeXPos;

    [SerializeField]
    float generateLevelWaitTime = 3f;
    float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialGroundsAndTrees();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForGroundsAndTrees();
    }
    void GenerateInitialGroundsAndTrees()
    {
        var groundPosition = Vector3.zero;
        GameObject newGround;
        for (int i=0;i<groundsToSpawn;i++)
        {
            groundPosition = new Vector3(lastGroundXPos, ground_Y_Pos, 0f);
            newGround = Instantiate(groundPrefab,groundPosition,Quaternion.identity);
            newGround.transform.SetParent(transform);
            groundPool.Add(newGround);
            lastGroundXPos += ground_X_Distance;
        }

        var treePosition = Vector3.zero;
        GameObject newTree;
        for (int i = 0; i < groundsToSpawn; i++)
        {
            treePosition = new Vector3(lastTreeXPos, tree_Y_Pos, 0f);
            newTree = Instantiate(treePrefab, treePosition, Quaternion.identity);
            newTree.transform.SetParent(transform);
            treePool.Add(newTree);
            lastTreeXPos += tree_X_Distance;
        }
    }
    void SetNewGrounds()
    {
        var groundPosition = Vector3.zero;
        for (int i=0;i<groundPool.Count;i++)
        {
            if (!groundPool[i].activeInHierarchy)
            {
                groundPosition = new Vector3(lastGroundXPos, ground_Y_Pos, 0f);
                groundPool[i].transform.position = groundPosition;
                groundPool[i].SetActive(true);
                lastGroundXPos += ground_X_Distance;
            }
        }
    }
    void SetNewTrees()
    {
        var treePosition = Vector3.zero;
        for (int i = 0; i < treePool.Count; i++)
        {
            if (!treePool[i].activeInHierarchy)
            {
                treePosition = new Vector3(lastTreeXPos, tree_Y_Pos, 0f);
                treePool[i].transform.position = treePosition;
                treePool[i].SetActive(true);
                lastTreeXPos += tree_X_Distance;
            }
        }
    }
    void CheckForGroundsAndTrees()
    {
        if (Time.time>waitTime)
        {
            SetNewGrounds();
            SetNewTrees();
            waitTime = Time.time + generateLevelWaitTime;
        }
    }

}
