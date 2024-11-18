using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : GunSkeleton
{

    [SerializeField] AudioSource gunSoundManager;
    [SerializeField] AudioClip shout;
    [SerializeField] AudioClip reload;
    public Image gun;
    public TextMeshProUGUI magazine;
    // Start is called before the first frame update
    void Start()
    {
        if (SetStats.damage != 0)
        {

            this.damage = SetStats.damage;
            this.gun.sprite = SetStats.gunSprite;
            this.gunSpeed = SetStats.gunSpeed;
            this.maxMuzzle = SetStats.maxMuzzle;
            this.auto = SetStats.auto;
            this.magazineTime = SetStats.magazineTime;
            
        }
        this.maxMuzzle += SetStats.increaseMuzzle;
    }
   

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && canShoot && maxMuzzle > muzzled)
        {
            muzzled++;
            Invoke(nameof(CooldownFinished), gunSpeed);
            gunSoundManager.clip = shout;
            gunSoundManager.Play();

            Vector2 mousePos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {

                if (hit.transform.gameObject.GetComponent<IDamageAble>() != null)
                {

                    GiveDamage(hit.transform.gameObject);

                }
            }
        }

        magazine.text = maxMuzzle - muzzled + "/" + maxMuzzle;

        magazine.color = new Color(((float)muzzled / maxMuzzle), ((float)(maxMuzzle - muzzled) / maxMuzzle), 0);
        if (Input.GetKeyDown(KeyCode.R) && magazined)
        {
            
            gunSoundManager.clip = reload;
            gunSoundManager.Play();
            Reload();
        }
        if (Input.GetMouseButton(0) && auto && maxMuzzle > muzzled)
        {
            if (canShoot)
            {
                canShoot = false;
                muzzled++;
                Invoke(nameof(CooldownFinished), gunSpeed);
                Debug.Log("Geldi");
                gunSoundManager.clip = shout;
                gunSoundManager.Play();

                Vector2 mousePos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (hit.collider != null)
                {

                    if (hit.transform.gameObject.GetComponent<IDamageAble>() != null)
                    {
                        Debug.Log("geldi");



                        GiveDamage(hit.transform.gameObject);





                    }
                }
            }
        }
    }

}
