using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    [HideInInspector] public Button CurrentSelected;
    private bool _initialLoad = true;

    public Weapons Weapons;

    [Header("First weapon")]
    [SerializeField] private Button _firstWeaponBtn;
    [SerializeField] private Image _firstWeaponGfx;

    [Header("Second weapon")]
    [SerializeField] private Button _secondWeaponBtn;
    [SerializeField] private Image _secondWeaponGfx;

    [Header("Thrid weapon")]
    [SerializeField] private Button _thridWeaponBtn;
    [SerializeField] private Image _thridWeaponGfx;

    [Header("Fourth weapon")]
    [SerializeField] private Button _fourthWeaponBtn;
    [SerializeField] private Image _fourthWeaponGfx;

    private void OnEnable()
    {
        if (_initialLoad)
        {
            switch (Weapons.InitialWeapon)
            {
                case InitialWeaponEnum.FirstWeapon:
                    CurrentSelected = _firstWeaponBtn;
                    break;
                case InitialWeaponEnum.SecondWeapon:
                    CurrentSelected = _secondWeaponBtn;
                    break;
                case InitialWeaponEnum.ThirdWeapon:
                    CurrentSelected = _thridWeaponBtn;
                    break;
                case InitialWeaponEnum.FourthWeapon:
                    CurrentSelected = _fourthWeaponBtn;
                    break;
            };
            _initialLoad = false;
        }
        SetFirstSelectedButton(CurrentSelected);
    }

    private void Start()
    {
        if (!Weapons.UnlockedWeapons["FirstWeapon"])
        {
            _firstWeaponBtn.interactable = false;
            _firstWeaponGfx.color = new Color(255, 255, 255, 0);
        }
        if (!Weapons.UnlockedWeapons["SecondWeapon"])
        {
            _secondWeaponBtn.interactable = false;
            _secondWeaponGfx.color = new Color(255, 255, 255, 0);
        }
        if (!Weapons.UnlockedWeapons["ThirdWeapon"])
        {
            _thridWeaponBtn.interactable = false;
            _thridWeaponGfx.color = new Color(255, 255, 255, 0);
        }
        if (!Weapons.UnlockedWeapons["FourthWeapon"])
        {
            _fourthWeaponBtn.interactable = false;
            _fourthWeaponGfx.color = new Color(255, 255, 255, 0);
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
            case "FirstWeapon":
                _firstWeaponBtn.interactable = true;
                _firstWeaponGfx.color = new Color(255, 255, 255, 255);
                break;
            case "SecondWeapon":
                _secondWeaponBtn.interactable = true;
                _secondWeaponGfx.color = new Color(255, 255, 255, 255);
                break;
            case "ThridWeapon":
                _thridWeaponBtn.interactable = true;
                _thridWeaponGfx.color = new Color(255, 255, 255, 255);
                break;
            case "FourthWeapon":
                _fourthWeaponBtn.interactable = true;
                _fourthWeaponGfx.color = new Color(255, 255, 255, 255);
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
