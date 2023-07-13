using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public enum InitialWeaponEnum { FirstWeapon, SecondWeapon, ThirdWeapon, FourthWeapon }

public class Weapons : MonoBehaviour
{
    private NewControls _newControls;

    [Header("Weapons")]
    public InitialWeaponEnum InitialWeapon;
    public Weapon FirstWeapon;
    public Weapon SecondWeapon;
    public Weapon ThirdWeapon;
    public Weapon FourthWeapon;

    [Header("Other components")]
    public HUD HUD;
    public WeaponWheel WeaponWheel;

    public Dictionary<string, bool> UnlockedWeapons = new()
        {
            { "FirstWeapon", true }, { "SecondWeapon", true }, { "ThirdWeapon", true }, { "FourthWeapon", true }
        };

    private float _weaponWheelInputValue;

    private void Awake()
    {
        _newControls = new NewControls();
        _newControls.WeaponWheelMap.Enable();
    }

    private void Start()
    {
        _newControls.WeaponWheelMap.OpenWeaponWheel.performed += OnOpenWeaponWheel;

        // Check unlocked weapons.
        if (UnlockedWeapons.Any(x => x.Value))
        {
            // Set initial weapon.
            SelectWeapon(InitialWeapon.ToString());
        }
    }

    private void Update()
    {
        _weaponWheelInputValue = _newControls.WeaponWheelMap.OpenWeaponWheel.ReadValue<float>();
    }

    private void SelectWeapon(string weaponName)
    {
        switch (weaponName)
        {
            case "FirstWeapon":
                SetActiveWeaponGameobject("FirstWeapon");
                HUD.SetWeaponData(FirstWeapon);
                break;
            case "SecondWeapon":
                SetActiveWeaponGameobject("SecondWeapon");
                HUD.SetWeaponData(SecondWeapon);
                break;
            case "ThirdWeapon":
                SetActiveWeaponGameobject("ThirdWeapon");
                HUD.SetWeaponData(ThirdWeapon);
                break;
            case "FourthWeapon":
                SetActiveWeaponGameobject("FourthWeapon");
                HUD.SetWeaponData(FourthWeapon);
                break;
        }
    }

    private void SetActiveWeaponGameobject(string weaponName)
    {
        if (FirstWeapon.name == weaponName) FirstWeapon.gameObject.SetActive(true); else FirstWeapon.gameObject.SetActive(false);
        if (SecondWeapon.name == weaponName) SecondWeapon.gameObject.SetActive(true); else SecondWeapon.gameObject.SetActive(false);
        if (ThirdWeapon.name == weaponName) ThirdWeapon.gameObject.SetActive(true); else ThirdWeapon.gameObject.SetActive(false);
        if (FourthWeapon.name == weaponName) FourthWeapon.gameObject.SetActive(true); else FourthWeapon.gameObject.SetActive(false);
    }

    public void OnOpenWeaponWheel(InputAction.CallbackContext context)
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
                case "FirstWeapon":
                    SelectWeapon("FirstWeapon");
                    break;
                case "SecondWeapon":
                    SelectWeapon("SecondWeapon");
                    break;
                case "ThirdWeapon":
                    SelectWeapon("ThirdWeapon");
                    break;
                case "FourthWeapon":
                    SelectWeapon("FourthWeapon");
                    break;
            }
        }
    }
}