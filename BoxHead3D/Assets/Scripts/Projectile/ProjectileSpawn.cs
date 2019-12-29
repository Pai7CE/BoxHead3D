using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject muzzleFlash;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject projectileToSpawn;
    private GameObject muzzleToSpawn;
    private GameObject vfxMuzzle;
    private float timeToFire = 0;

    void Start()
    {
        projectileToSpawn = vfx[0];
        muzzleToSpawn = vfx[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / projectileToSpawn.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();
        }
        //Updating muzzle spawn point so it moves with the player
        if(vfxMuzzle != null)
        {
        vfxMuzzle.transform.rotation = firePoint.transform.rotation;
        vfxMuzzle.transform.position = firePoint.transform.position;
        }
    }
    
    public void SpawnVFX()
    {
        GameObject vfxProjectile;
        if(firePoint != null)
        {
            vfxProjectile = Instantiate(projectileToSpawn, firePoint.transform.position, Quaternion.identity);
            vfxProjectile.transform.rotation = gameObject.transform.rotation;
            vfxMuzzle = Instantiate(muzzleToSpawn, firePoint.transform.position, Quaternion.identity);
            vfxMuzzle.transform.rotation = gameObject.transform.rotation;
            Destroy(vfxMuzzle, .5f);
        }
        else
        {
            Debug.Log("No fire Point");
        }
    }
}
