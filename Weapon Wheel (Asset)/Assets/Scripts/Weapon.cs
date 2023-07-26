using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private Weapons _weapons;
    public WeaponScriptableObject WeaponSettings;
    [HideInInspector] public int CurrentBulletCount;

    private SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        CurrentBulletCount = WeaponSettings.MaxAmmo;

        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = WeaponSettings.Sprite;
    }

    private void Start()
    {
        _weapons = GetComponentInParent<Weapons>();
        GameManager.NewControls.WeaponWheelMap.Shoot.performed += OnShoot;
        GameManager.NewControls.WeaponWheelMap.Reload.performed += OnReload;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (gameObject.activeInHierarchy)
        {
            if (CurrentBulletCount > 0)
            {
                CurrentBulletCount--;
                _weapons.HUD.SetWeaponData(this);
            }
            else Debug.Log("No ammo");
        }
    }

    private void OnReload(InputAction.CallbackContext context)
    {
        CurrentBulletCount = WeaponSettings.MaxAmmo;
        _weapons.HUD.SetWeaponData(this);
    }
}
