using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponScriptableObject WeaponSettings;
    public int CurrentBulletCount;

    private void Awake()
    {
        CurrentBulletCount = WeaponSettings.MaxBullets;
    }
}
