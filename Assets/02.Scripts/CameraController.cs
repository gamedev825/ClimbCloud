using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    //public Transform target;
    //public Vector3 fixedXZ = new Vector3(0f, 0f, 0f);
    //public float smoothSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        
        
        //Vector3 currentPos = transform.position;

        //Vector3 targetPos = new Vector3(
        //        fixedXZ.x,
        //        target.position.y,
        //        fixedXZ.z
        //);

        //transform.position = Vector3.Lerp(currentPos, targetPos, Time.deltaTime * smoothSpeed);

        //transform.LookAt(target);

        //transform.rotation = Quaternion.identity;
    }


}
