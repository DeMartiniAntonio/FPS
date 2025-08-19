using System;
using System.Collections;
using TMPro;
using UnityEngine;


public enum FireMode
{
    SemiAuto,
    FullAuto,
    Burst
}

public class Gun : MonoBehaviour
{
    private FireMode fireMode = FireMode.SemiAuto;

    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private TMP_Text maxAmmoText;
    [SerializeField] private GameObject gun;
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float minZoom = 60f;
    [SerializeField] private float maxZoom = 30f;
    private float nextFireTime = 0f;
    private int maxAmmoCount = 30; 
    private int ammoCount;

    [SerializeField] private int allAmooCount = 90;
    [SerializeField] private int leftAmmoCount;
    [SerializeField] private int ammoToReload;
    private bool isReloading = false;


    //reload, scope, skins, firemode
    private void Start()
    {
        ammoCount = maxAmmoCount; 
        ammoText.text = $"{ammoCount}/{maxAmmoCount}";
        maxAmmoText.text = $"{leftAmmoCount}/{allAmooCount}";
        leftAmmoCount = allAmooCount;
        
    }
    private void Update()
    {
        //Shoot
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && ammoCount > 0)
        {
            Shoot();
        }
        //Reload
        if (ammoCount == 0 || Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(leftAmmoCount);
            if (leftAmmoCount == 0)
            {
                maxAmmoText.text = $"{leftAmmoCount}/{allAmooCount}";
            }
            
            else if (leftAmmoCount > 0 && !isReloading && Time.time >= nextFireTime)
            {
                if (leftAmmoCount >= maxAmmoCount)
                {
                    leftAmmoCount += ammoCount;
                    ammoToReload = maxAmmoCount;
                }
                else if (leftAmmoCount > 0 && leftAmmoCount < maxAmmoCount)
                {
                    leftAmmoCount += ammoCount;
                    ammoToReload = leftAmmoCount;
                }
                leftAmmoCount -= ammoToReload;
                
                StartCoroutine(Reload());
                maxAmmoText.text = $"{leftAmmoCount}/{allAmooCount}";
                ammoText.text = $"{ammoCount}/{maxAmmoCount}";
            }
        }
        //Scope
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(SetZoom(minZoom, maxZoom));
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StartCoroutine(SetZoom(maxZoom, minZoom));
        }
        //Change Fire Mode
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fireMode = FireMode.SemiAuto;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            fireMode = FireMode.FullAuto;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            fireMode = FireMode.Burst;
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 2f;
            Quaternion targetRotation = Quaternion.Euler(gun.transform.rotation.eulerAngles.x, gun.transform.rotation.eulerAngles.y - 60f, gun.transform.rotation.eulerAngles.z);
            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, targetRotation, Time.deltaTime * 2f);
            yield return new WaitForSeconds(2f);

            ammoCount = ammoToReload;
            ammoText.text = $"{ammoCount}/{maxAmmoCount}";
            targetRotation = Quaternion.Euler(gun.transform.rotation.eulerAngles.x, gun.transform.rotation.eulerAngles.y + 60f, gun.transform.rotation.eulerAngles.z);
            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, targetRotation, Time.deltaTime * 2f);
        }
        isReloading = false;

    }

    private IEnumerator SetZoom(float start, float end) {

        float timer = 1;
        float elapse = 0.2f;
        while (timer > 1)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            playerCamera.fieldOfView = Mathf.Lerp(start, end, timer/elapse);
        }
    }

    private void Shoot()
    {
        switch (fireMode)
        {
            case FireMode.SemiAuto:
                FireBullet(1f);
                break;
            case FireMode.FullAuto:
                FireBullet(0.1f);
                break;
            case FireMode.Burst:
                StartCoroutine(FireBurst());

                break;
                
        }
    }

    private IEnumerator FireBurst()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 0.9f;
            GameObject createBullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            Rigidbody bulletRb = createBullet.GetComponent<Rigidbody>();
            bulletRb.linearVelocity = muzzle.forward * 100f;
            ammoCount--;
            ammoText.text = $"{ammoCount}/{maxAmmoCount}";
            yield return new WaitForSeconds(0.1f);
            createBullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            bulletRb = createBullet.GetComponent<Rigidbody>();
            bulletRb.linearVelocity = muzzle.forward * 100f;
            ammoCount--;
            ammoText.text = $"{ammoCount}/{maxAmmoCount}";
            yield return new WaitForSeconds(0.1f);
            createBullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            bulletRb = createBullet.GetComponent<Rigidbody>();
            bulletRb.linearVelocity = muzzle.forward * 100f;
            ammoCount--;
            ammoText.text = $"{ammoCount}/{maxAmmoCount}";
            yield return new WaitForSeconds(0.7f);
        }
    }

    private void FireBullet(float fireRateForEnum)
    {
        if (Time.time >= nextFireTime) {
            GameObject createBullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            Rigidbody bulletRb = createBullet.GetComponent<Rigidbody>();
            bulletRb.linearVelocity = muzzle.forward * 100f;
            nextFireTime = Time.time + fireRateForEnum;
            ammoCount--;
            ammoText.text = $"{ammoCount}/{maxAmmoCount}";
        }
    }
}
