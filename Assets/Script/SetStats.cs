
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStats : MonoBehaviour
{


    public static Sprite gunSprite;
    public static float damage;
    public static float gunSpeed;
    public static int maxMuzzle;
    public static float magazineTime;
    public static bool  auto;
    public static int healer;
    public static int ammor;
    public static float wholeMoney = 100000;
    public static int increaseMuzzle;

    public static void UpdateMoney(float deger)
    {
        UIController.money += (int)deger;
    }
    public static List<bool> purchased=new List<bool>();
    
}
