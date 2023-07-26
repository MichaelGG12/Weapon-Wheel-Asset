using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Weapons _weapons;

    public WeaponScriptableObject WeaponSettings;
    public int CurrentBulletCount;

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
        GameManager.NewControls.WeaponWheelMap.Shoot.performed += OnShootPressed;
    }

    private void OnShootPressed(InputAction.CallbackContext context)
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
}
