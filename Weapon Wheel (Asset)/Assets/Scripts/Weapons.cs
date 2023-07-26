using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public enum InitialWeaponEnum { Pistol, Magnum, Rifle, SMG }

public class Weapons : MonoBehaviour
{
    [Header("Weapons")]
    public InitialWeaponEnum InitialWeapon;
    public Weapon Pistol;
    public Weapon Magnum;
    public Weapon Rifle;
    public Weapon SMG;

    [Header("Other components")]
    public HUD HUD;
    public WeaponWheel WeaponWheel;

    public Dictionary<string, bool> UnlockedWeapons = new()
        {
            { "Pistol", true }, { "Magnum", true }, { "Rifle", true }, { "SMG", true }
        };

    private float _weaponWheelInputValue;


    private void Start()
    {
        GameManager.NewControls.WeaponWheelMap.OpenWeaponWheel.performed += OnOpenWeaponWheel;

        if (UnlockedWeapons.Any(x => x.Value))
        {
            SelectWeapon(InitialWeapon.ToString());
        }
    }

    private void Update()
    {
        _weaponWheelInputValue = GameManager.NewControls.WeaponWheelMap.OpenWeaponWheel.ReadValue<float>();
    }

    private void SelectWeapon(string weaponName)
    {
        switch (weaponName)
        {
            case "Pistol":
                SetActiveWeaponGameobject("Pistol");
                HUD.SetWeaponData(Pistol);
                break;
            case "Magnum":
                SetActiveWeaponGameobject("Magnum");
                HUD.SetWeaponData(Magnum);
                break;
            case "Rifle":
                SetActiveWeaponGameobject("Rifle");
                HUD.SetWeaponData(Rifle);
                break;
            case "SMG":
                SetActiveWeaponGameobject("SMG");
                HUD.SetWeaponData(SMG);
                break;
        }
    }

    private void SetActiveWeaponGameobject(string weaponName)
    {
        if (Pistol.name == weaponName) Pistol.gameObject.SetActive(true); else Pistol.gameObject.SetActive(false);
        if (Magnum.name == weaponName) Magnum.gameObject.SetActive(true); else Magnum.gameObject.SetActive(false);
        if (Rifle.name == weaponName) Rifle.gameObject.SetActive(true); else Rifle.gameObject.SetActive(false);
        if (SMG.name == weaponName) SMG.gameObject.SetActive(true); else SMG.gameObject.SetActive(false);
    }

    private void OnOpenWeaponWheel(InputAction.CallbackContext context)
    {
        if (_weaponWheelInputValue == 0) // Pressed.
        {
            WeaponWheel.gameObject.SetActive(true);
        }
        else if (_weaponWheelInputValue == 1) // Released.
        {
            WeaponWheel.gameObject.SetActive(false);
            ChangeWeapon();
        }      
    }

    private void ChangeWeapon()
    {
        if (UnlockedWeapons.Any(x => x.Value))
        {
            switch (WeaponWheel.CurrentSelected.gameObject.name)
            {
                case "Pistol":
                    SelectWeapon("Pistol");
                    break;
                case "Magnum":
                    SelectWeapon("Magnum");
                    break;
                case "Rifle":
                    SelectWeapon("Rifle");
                    break;
                case "SMG":
                    SelectWeapon("SMG");
                    break;
            }
        }
    }
}