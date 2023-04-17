using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon : MonoBehaviour
{
    public List<weaponController> startingWeapons = new List<weaponController>();

    public Transform weaponParentSocket;
    public Transform defaultWeaponPosition;
    public Transform aimingPosition;

    public int activeWeaponIndex { get; private set;  }

    private weaponController[] weaponSlots = new weaponController[5];
    // Start is called before the first frame update
    void Start()
    {
        activeWeaponIndex = -1;

        foreach (weaponController startingWeapon in startingWeapons)
        {
            AddWeapon(startingWeapon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
    }

    private void SwitchWeapon(int p_weaponIndex)
    {
        if (p_weaponIndex != activeWeaponIndex && p_weaponIndex >= 0)
        {
            weaponSlots[p_weaponIndex].gameObject.SetActive(true);
            activeWeaponIndex = p_weaponIndex;
        }
    }

    private void AddWeapon(weaponController p_weaponPrefab)
    {
        weaponParentSocket.position = defaultWeaponPosition.position;

        for (int i = 0; i<weaponSlots.Length; i++)
        {
            if(weaponSlots[i] == null)
            {
                weaponController weaponClone = Instantiate(p_weaponPrefab, weaponParentSocket);
                weaponClone.gameObject.SetActive(false);

                weaponSlots[i] = weaponClone;
                return;
            }
        }
    }

}
