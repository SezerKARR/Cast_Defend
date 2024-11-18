using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSkeleton : MonoBehaviour
{
    
    [SerializeField] protected float damage=1;
    
    
    protected float time;
    public int maxMuzzle=10;
    public float gunSpeed = 0.4f;
    public float magazineTime = 2;
    protected int muzzled;
    protected bool magazined=true;
    [SerializeField] protected bool auto;
    [SerializeField] protected float bulletDelay = 1f;

    // A flag indicating whether this weapon can currently shoot
    protected bool canShoot = true;
    public void Start()
    {


    }
    public void GiveDamage(GameObject enemy)
    {
         
            enemy.GetComponent<IDamageAble>().TakeDamage(damage);
            //muzzleEffect.GetComponent<ParticleSystem>().Play();
            time = 0;
            
       
        
    }
    protected void Reload()
    {
        magazined = false;
        canShoot = false;
        StartCoroutine(ReloadTime());
        
       
    }
    private IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(magazineTime);
        muzzled = 0;
        magazined = true;
        canShoot = true;
    }

    protected void CooldownFinished()
    {
        if (magazined)
        {

            canShoot = true;
        }
    }

}
