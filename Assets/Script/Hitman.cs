using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitman : GunSkeleton
{
    public ParticleSystem muzzleEffect;
    public static GameObject[] enemys;
    public Animator anim;
    private AudioSource hitmanSound;
    [SerializeField] AudioClip shout;
    [SerializeField] AudioClip reload;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        hitmanSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if ( canShoot)
        {
            if (GameController.enemys.Count > 0)
            {
                anim.SetBool("Attack", true);
                
                
            }

            else if (GameController.enemys.Count == 0)
            {
                anim.SetBool("Attack", false);
                
            }



        }
    }
    public void Damage()
    {
        if (GameController.enemys.Count > 0)
        {
            int posEnemy = Random.RandomRange(0, GameController.enemys.Count);
            if (GameController.enemys[posEnemy] != null)
            {

                canShoot = false;

                GiveDamage(GameController.enemys[posEnemy]);
                Invoke(nameof(CooldownFinished), gunSpeed);

            }
        }
       
    }
    public void Muzzle()
    {
        muzzleEffect.Play();
        hitmanSound.clip = shout;
        hitmanSound.Play();
    }
    
}
