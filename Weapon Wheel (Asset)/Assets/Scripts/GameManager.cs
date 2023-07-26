using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static NewControls NewControls;

    private void Awake()
    {
        NewControls = new NewControls();
        NewControls.WeaponWheelMap.Enable();
    }
}
