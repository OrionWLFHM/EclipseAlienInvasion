using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject weaponInfoPrefab;

    private void Start()
    {
        eventManager.current.newGunEvent.AddListener(CreateWeaponInfo);
    }

    public void CreateWeaponInfo()
    {
        Instantiate(weaponInfoPrefab, transform);
    }
}
