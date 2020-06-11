using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public float damage =10f;
	public float range = 100f;
	public Camera fpsCam;
	public ParticleSystem muzzleFlash;
	public ParticleSystem bulletTrace;
	public GameObject impactEffect;
	public float impactForce =10f;

	public float fireRate = 15f;
	private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
        	nextTimeToFire = Time.time + 1f/fireRate;
        	Shoot();
        }
    }

    void Shoot()
    {
    	if(weaponSwitch.selectedWeapon == 1)
    	{
    		FindObjectOfType<AudioManager>().Play("Shotgun Shot");
    	}
    	else if(weaponSwitch.selectedWeapon == 0)
    	{
    		FindObjectOfType<AudioManager>().Play("Alien Shot");
    	}
    	else
    	{
    		FindObjectOfType<AudioManager>().Play("Shot");
    	}
        
    	muzzleFlash.Play();
    	//bulletTrace.Play();
    	RaycastHit hit;
    	if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    	{
    		enemy target = hit.transform.GetComponent<enemy>();
    		if(target != null)
    		{
    			target.TakeDamage(damage);
    		}

    		if(hit.rigidbody != null)
    		{
    			hit.rigidbody.AddForce(-hit.normal * impactForce);
    		}

    		GameObject impactGO = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
    		Destroy(impactGO, 2f);
    	}
    }
}
