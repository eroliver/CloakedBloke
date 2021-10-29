using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class should be built to control player projectile abilities
public class ProjectileSpawner : MonoBehaviour
{
    //need to define this at run time based on the projectile....
    [SerializeField]
    private LayerMask targetableLayers;
    [SerializeField]
    private Transform raycastOrigin;
    [SerializeField]
    private GameObject projectile;

    private void Start()
    {
        if (raycastOrigin == null)
        {
            raycastOrigin = GameObject.Find("CameraTarget").transform;
        }
    }

    public void fireProjectile(GameObject projectileAbility)
    {
        //play animation for firing the abailty here
        //anim.play


        RaycastHit targetHit;
        if (Physics.Raycast(raycastOrigin.transform.position, raycastOrigin.transform.forward, out targetHit, 1000f, targetableLayers))
        {

            GameObject projectileInstance = Instantiate(projectileAbility, transform.position, transform.rotation);
            projectileInstance.transform.LookAt(targetHit.point);
        }
        else
        {
            //allow player to fire without a target, aims for 100 units forward through the camera
            GameObject projectileInstance = Instantiate(projectileAbility, transform.position, transform.rotation);
            projectileInstance.transform.LookAt((raycastOrigin.transform.position + (raycastOrigin.transform.forward * 100)));
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
    }
}
