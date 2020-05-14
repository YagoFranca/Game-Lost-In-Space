using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;

    public Animator an;

    void Update()
    {
        an = GetComponent<Animator>();
    }


    public void Button()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

	public void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        an.SetBool("IsFire",false);
    }
}
