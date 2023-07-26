using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("UI Componentes")]
    public Image Icon;
    public Text AmmoTxt;

    public void SetWeaponData(Weapon weapon)
    {
        if (weapon != null)
        {
            Icon.sprite = weapon.WeaponSettings.Icon;
            AmmoTxt.text = $"{weapon.CurrentBulletCount} / {weapon.WeaponSettings.MaxAmmo}";
        }
    }
}