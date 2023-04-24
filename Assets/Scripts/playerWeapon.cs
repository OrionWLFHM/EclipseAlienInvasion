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

    private weaponController[] weaponSlots = new weaponController[2];
    // Start is called before the first frame update
    void Start()
    {
        activeWeaponIndex = -1;

        foreach (weaponController startingWeapon in startingWeapons)
        {
            AddWeapon(startingWeapon);
        }
        SwitchWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon();
        }
    }

    private void SwitchWeapon()
    {
        int tempIndex = (activeWeaponIndex + 1) % weaponSlots.Length;

        if (weaponSlots[tempIndex] == null)
            return;

        foreach(weaponController weapon in weaponSlots)
        {
            if (weapon != null) weapon.gameObject.SetActive(false);
        }

        weaponSlots[tempIndex].gameObject.SetActive(true);
        activeWeaponIndex = tempIndex;

        eventManager.current.newGunEvent.Invoke();
    }

    private void AddWeapon(weaponController p_weaponPrefab)
    {
        weaponParentSocket.position = defaultWeaponPosition.position;

        for (int i = 0; i<weaponSlots.Length; i++)
        {
            if(weaponSlots[i] == null)
            {
                weaponController weaponClone = Instantiate(p_weaponPrefab, weaponParentSocket);
                weaponClone.owner = gameObject;
                weaponClone.gameObject.SetActive(false);

                weaponSlots[i] = weaponClone;
                return;
            }
        }
    }

}
