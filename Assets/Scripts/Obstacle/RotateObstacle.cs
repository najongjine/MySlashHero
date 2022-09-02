using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    float rotateSpeed = 300f;
    float zAngle;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(300, 400);
        if (Random.Range(0,2)>0)
        {
            rotateSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        zAngle+=Time.deltaTime*rotateSpeed;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);
    }
}
