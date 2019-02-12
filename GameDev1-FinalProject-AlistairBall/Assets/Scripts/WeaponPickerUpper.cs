using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickerUpper : MonoBehaviour
{

    GameObject weapon;
    GameObject weapon2;
    GameObject weaponAttach;
    // Use this for initialization
    void Start()
    {
        if (!weaponAttach)
        {
            weaponAttach = GameObject.Find("WeaponAttachPoint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && weapon)
        {
            weaponAttach.transform.DetachChildren();

            Physics.IgnoreCollision(transform.GetComponent<Collider>(),
                weapon.GetComponent<Collider>(), false);

            weapon.GetComponent<Rigidbody>().isKinematic = true;

            weapon.GetComponent<Rigidbody>().AddRelativeForce(
                weaponAttach.transform.forward * 10, ForceMode.Impulse);

            weapon = null;
        }

        if(Input.GetKeyDown(KeyCode.T) && weapon2)
        {
            weaponAttach.transform.DetachChildren();

            Physics.IgnoreCollision(transform.GetComponent<Collider>(),
                weapon2.GetComponent<Collider>(), false);

            weapon2.GetComponent<Rigidbody>().isKinematic = true;

            weapon2.GetComponent<Rigidbody>().AddRelativeForce(
                weaponAttach.transform.forward * 10, ForceMode.Impulse);

            weapon2 = null;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (weapon)
            {
                WeaponShoot w = weapon.GetComponent<WeaponShoot>();
                if (w)
                {
                    w.Shoot();
                }
            }

            else if (weapon2)
            {
                WeaponShoot w = weapon2.GetComponent<WeaponShoot>();
                if (w)
                {
                    w.GrenadeLaunch();
                }
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit c)
    {
        if (c.gameObject.tag == "Weapon")
        {
            weapon = c.gameObject;

            //turn off physics for gun
            weapon.GetComponent<Rigidbody>().isKinematic = true;
            //
            weapon.transform.SetPositionAndRotation(weaponAttach.transform.position,
                weaponAttach.transform.localRotation);


            weapon.transform.SetParent(weaponAttach.transform);

            weapon.transform.localRotation =
                weaponAttach.transform.localRotation;

            //ignore collisions between the character and the weapon
            Physics.IgnoreCollision(transform.GetComponent<Collider>(),
                weapon.GetComponent<Collider>());
        }

        else if (c.gameObject.tag == "GrenadeWeapon")
        {
            weapon2 = c.gameObject;

            //turn off physics for gun
            weapon2.GetComponent<Rigidbody>().isKinematic = true;
            //
            weapon2.transform.SetPositionAndRotation(weaponAttach.transform.position,
                weaponAttach.transform.localRotation);


            weapon2.transform.SetParent(weaponAttach.transform);

            weapon2.transform.localRotation =
                weaponAttach.transform.localRotation;

            //ignore collisions between the character and the weapon
            Physics.IgnoreCollision(transform.GetComponent<Collider>(),
                weapon2.GetComponent<Collider>());

        }
    }
}
