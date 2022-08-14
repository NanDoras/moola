using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 Offset; 
    public GameObject stage;

    private float xRotateMove, yRotateMove;

    public float rotateSpeed = 500.0f;

    //void Update()
    //{
     //   if (Input.GetMouseButton(0))
      //  {
       //     xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
//
 //           Vector3 stagePosition = stage.transform.position;

  //          transform.RotateAround(stagePosition, Vector3.up, xRotateMove);

   //         transform.LookAt(stagePosition);
        //}
    ////////////////}

    void Awake()
    {
        Offset = transform.position - playerTransform.position;
    }

    public void LateUpdate()
    {
        //if(Input.GetMouseButton(1))
        //{
            transform.position = playerTransform.position + Offset;
        //}
    }

}
