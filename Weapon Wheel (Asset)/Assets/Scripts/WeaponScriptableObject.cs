using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon")]

public class WeaponScriptableObject : ScriptableObject
{
    [Header("UI Icon")]
    public Sprite Icon;

    [Header("Ammo")]
    public int MaxBullets;
}
