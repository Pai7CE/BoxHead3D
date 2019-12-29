using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;


    // Update is called once per frame
    void Update()
    {
        if(speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Speed zero");
        }

        Destroy(gameObject, 2);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        collision.gameObject.GetComponent<EnemyController>().reduceHealth();
    }
}
