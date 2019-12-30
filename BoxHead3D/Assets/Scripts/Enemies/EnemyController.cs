using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntitiyController
{
    CharacterController characterController;
    Transform transformTarget;
    Transform transformEntity;

    public float speed = 6.0f;
    public GameObject target;
    public bool movementPaused;


    private Vector3 heading = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private float health = 50;
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
                float yRotation = Vector3.Angle(new Vector3(0,0,1), heading);
                if(heading.x > 0)
                {
                    transformEntity.eulerAngles = new Vector3(0, yRotation, 0);
                }
                else
                {
                    transformEntity.eulerAngles = new Vector3(0, -yRotation, 0);
                }                               
            }

        }
    }

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        transformEntity = gameObject.GetComponent<Transform>();
        transformTarget = target.GetComponent<Transform>();
        StartCoroutine(EntitiyRotation());
    }

    // Update is called once per frame
    void Update()
    {
        if (!movementPaused)
        {
        movement();
        }
    }

    public override void movement()
    {
        heading = transformTarget.position - transformEntity.position;
        moveDirection = heading / heading.magnitude;
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void reduceHealth()
    {
        health -= 20;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
