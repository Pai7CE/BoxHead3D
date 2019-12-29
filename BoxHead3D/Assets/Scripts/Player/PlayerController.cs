using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerController  : EntitiyController
{

    CharacterController characterController;
    Transform transformEntity;


    public int health = 100;
    public float speed = 6.0f;
    
    private Vector3 moveDirection = Vector3.zero;


    IEnumerator EntitiyRotation()
    {
        while (true)
        {
            Vector3 oldPos = transformEntity.position;
            yield return new WaitForEndOfFrame();
            Vector3 newPos = transformEntity.position;
            Vector3 heading = (newPos - oldPos).normalized;
            if (heading != Vector3.zero)
            {
                float yRotation = Vector3.Angle(Vector3.forward, heading);
                if (Input.GetAxis("Horizontal") > 0)
                {
                    transformEntity.eulerAngles = new Vector3(0, yRotation, 0);
                }
                else
                {
                    transformEntity.eulerAngles = new Vector3(0, -yRotation, 0);
                }
                //print(yRotation);
            }

        }
    }


    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        transformEntity = gameObject.GetComponent<Transform>();
        StartCoroutine(EntitiyRotation());
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    public override void movement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);
    }
    public void rotation()
    {
        //Vector3 newRotation = entitiyTransform.eulerAngles;
        ////entitiyTransform.eulerAngles = new Vector3(0, RotationHelper.diaUL, 0);

        //if(Input.GetAxis("Vertical") > 0)
        //{
        //    if(Input.GetAxis("Horizontal") > 0)
        //    {
        //        newRotation.y = RotationHelper.diaUR;
        //    }
        //    if(Input.GetAxis("Horizontal") < 0)
        //    {
        //        newRotation.y = RotationHelper.diaUL;
        //    }
        //    if (Input.GetAxis("Horizontal") == 0)
        //    {
        //        newRotation.y = RotationHelper.up;
        //    }
        //}
        //if (Input.GetAxis("Vertical") < 0)
        //{
        //    if (Input.GetAxis("Horizontal") > 0)
        //    {
        //        newRotation.y = RotationHelper.diaDR;
        //    }
        //    if (Input.GetAxis("Horizontal") < 0)
        //    {
        //        newRotation.y = RotationHelper.diaDL;
        //    }
        //    if(Input.GetAxis("Horizontal") == 0)
        //    {
        //        newRotation.y = RotationHelper.down;
        //    }
        //}
        //if(Input.GetAxis("Vertical") == 0)
        //{
        //    if (Input.GetAxis("Horizontal") > 0)
        //    {
        //        newRotation.y = RotationHelper.right;
        //    }
        //    if (Input.GetAxis("Horizontal") < 0)
        //    {
        //        newRotation.y = RotationHelper.left;
        //    }
        //}

        //entitiyTransform.eulerAngles = newRotation;


    }
}
