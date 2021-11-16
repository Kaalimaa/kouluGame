using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class projectileGun : MonoBehaviour
{
    // Start is called before the first frame update
    //bullet
    public GameObject Bullet;

    // bulletforce
    public float sForce, upForce;

    //gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public bool allowButtonHold;
    public int magaSize, bulletPerTap;


    int bulletsLeft, bulletsShot;

    //bools 
    bool shoothing, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI AmmunationDisplay;

    //bug fix
    public bool allowInvoke = true;

    private void Awake()
    {
        //varmistaa ett‰ lipas on t‰ynn‰
        bulletsLeft = magaSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //set ammo display, JOS SELLANEN ON :P
        if (AmmunationDisplay != null)
            AmmunationDisplay.SetText(bulletsLeft / bulletPerTap + "/" + magaSize / bulletPerTap);
    }
    private void MyInput()
    {   
        //varmistaa saako pit‰‰ nappia pohjassa ja ottaa vastaavan inputin
        if (allowButtonHold) shoothing = Input.GetKey(KeyCode.Mouse0);
        else shoothing = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magaSize && !reloading) Reload();
        //Lataa automaatiseti jos ammut kun lipas tyhj‰
        if (readyToShoot && shoothing && !reloading && bulletsLeft <= 0) Reload();

        if (readyToShoot && shoothing && !reloading && bulletsLeft > 0)
        {
            //asettaa j‰jell‰ olevat ammukset nollaan
            bulletsShot = 0;

            Shoot();
        }

    }
    private void Shoot()
    {
        readyToShoot = false;

        //etsii osuma kohdan k‰ytt‰m‰ll‰ raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);//Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //adds spread to last direction

        //Instantiate Bullet/Projectile
        GameObject currentBullet = Instantiate(Bullet, attackPoint.position, Quaternion.identity); //store instant
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add force to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * sForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;
        //Instansiate muzzleFlash, if you have one selected
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        // Invoke resetShot function(if not already invoked)
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //if more tahn on bullet
        if (bulletsShot < bulletPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    
    private void ReloadFinished()
    {
        bulletsLeft = magaSize;
        reloading = false;
    }
}
