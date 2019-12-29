using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CharacterController characterController;
    Transform transformTarget;
    Transform transformEntity;

    public float speed = 6.0f;
    public GameObject target;
    public bool movementPaused;


    private Vector3 heading = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;



    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        transformEntity = gameObject.GetComponent<Transform>();
        transformTarget = target.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!movementPaused)
        {
        movement();
        }
    }

    public void movement()
    {
        heading = transformTarget.position - transformEntity.position;
        moveDirection = heading / heading.magnitude;
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
