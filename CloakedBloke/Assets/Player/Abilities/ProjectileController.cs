using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class should be built to control player projectile abilities
public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private LayerMask targetableLayers;

    [SerializeField]
    private Transform raycastOrigin;

    [SerializeField]
    private GameObject projectile;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((0)))
        {
            fireProjectile();
        }
    }

    public void fireProjectile()
    {
        //play animation for firing the abailty here
        //anim.play

        RaycastHit targetHit;
        if (Physics.Raycast(raycastOrigin.transform.position, raycastOrigin.transform.forward, out targetHit, 1000f, targetableLayers))
        {

            GameObject projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
            projectileInstance.transform.LookAt(targetHit.point);
        }
        else
        {
            //allow player to fire without a target, aims for 100 units forward through the camera
            GameObject projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
            projectileInstance.transform.LookAt((raycastOrigin.transform.position + (raycastOrigin.transform.forward * 100)));
        }
        
        //GameObject fireball = Instantiate(projectile, transform.position, transform.rotation);

    }
}
