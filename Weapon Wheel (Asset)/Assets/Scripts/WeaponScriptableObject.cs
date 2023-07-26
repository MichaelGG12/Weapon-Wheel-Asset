using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon")]

public class WeaponScriptableObject : ScriptableObject
{
    [Header("Sprite")]
    public Sprite Sprite;

    [Header("HUD")]
    public Sprite Icon;

    [Header("Ammo")]
    public int MaxAmmo;
}
