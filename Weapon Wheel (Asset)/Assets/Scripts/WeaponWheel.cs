using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    [HideInInspector] public Button CurrentSelected;
    private bool _initialLoad = true;

    public Weapons Weapons;

    [Header("Pistol")]
    [SerializeField] private Button _pistolBtn;
    [SerializeField] private Image _pistolGfx;

    [Header("Magnum")]
    [SerializeField] private Button _magnumBtn;
    [SerializeField] private Image _magnumGfx;

    [Header("Rifle")]
    [SerializeField] private Button _rifleBtn;
    [SerializeField] private Image _rifleGfx;

    [Header("SMG")]
    [SerializeField] private Button _SMGBtn;
    [SerializeField] private Image _SMGGfx;

    private void OnEnable()
    {
        if (_initialLoad)
        {
            switch (Weapons.InitialWeapon)
            {
                case InitialWeaponEnum.Pistol:
                    CurrentSelected = _pistolBtn;
                    break;
                case InitialWeaponEnum.Magnum:
                    CurrentSelected = _magnumBtn;
                    break;
                case InitialWeaponEnum.Rifle:
                    CurrentSelected = _rifleBtn;
                    break;
                case InitialWeaponEnum.SMG:
                    CurrentSelected = _SMGBtn;
                    break;
            };
            _initialLoad = false;
        }
        SetFirstSelectedButton(CurrentSelected);
    }

    private void Start()
    {
        _pistolGfx.sprite = Weapons.Pistol.WeaponSettings.Icon;
        _magnumGfx.sprite = Weapons.Magnum.WeaponSettings.Icon;
        _rifleGfx.sprite = Weapons.Rifle.WeaponSettings.Icon;
        _SMGGfx.sprite = Weapons.SMG.WeaponSettings.Icon;

        if (!Weapons.UnlockedWeapons["Pistol"])
        {
            _pistolBtn.interactable = false;
            _pistolGfx.color = new Color(255, 255, 255, 0);
        }
        if (!Weapons.UnlockedWeapons["Magnum"])
        {
            _magnumBtn.interactable = false;
            _magnumGfx.color = new Color(255, 255, 255, 0);
        }
        if (!Weapons.UnlockedWeapons["Rifle"])
        {
            _rifleBtn.interactable = false;
            _rifleGfx.color = new Color(255, 255, 255, 0);
        }
        if (!Weapons.UnlockedWeapons["SMG"])
        {
            _SMGBtn.interactable = false;
            _SMGGfx.color = new Color(255, 255, 255, 0);
        }
    }

    public void SetFirstSelectedButton(Button firstSelected)
    {
        firstSelected.Select();
    }

    public void UnlockWeapon(string weaponName)
    {
        switch (weaponName)
        {
            case "Pistol":
                _pistolBtn.interactable = true;
                _pistolGfx.color = new Color(255, 255, 255, 255);
                break;
            case "Magnum":
                _magnumBtn.interactable = true;
                _magnumGfx.color = new Color(255, 255, 255, 255);
                break;
            case "Rifle":
                _rifleBtn.interactable = true;
                _rifleGfx.color = new Color(255, 255, 255, 255);
                break;
            case "SMG":
                _SMGBtn.interactable = true;
                _SMGGfx.color = new Color(255, 255, 255, 255);
                break;
        }
    }

    private void Update()
    {
        if (Weapons.UnlockedWeapons.Any(x => x.Value) && gameObject.activeInHierarchy)
        {
            CurrentSelected = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        }
    }
}
