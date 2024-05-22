using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GunWorkings : MonoBehaviour
{
    /*********************************
     * this is the controller for the gun
     * and shoots the given object.
     *
     *Teddy Fleitas 5/14/24
     ********************************/

    public UnityEvent OnGunShoot;   //event to see when gun shoot
    public float FireCooldown;      //guns cooldown time
    //public bool Automatic;          //decides if gun is auto or not
    private float CurrentCooldown;  //holds cooldown time between shots
    [SerializeField] private InputActionReference shootInput;  //gets shoot input
    [SerializeField] private GameObject projectile;  //projectile game object
    [SerializeField] private Transform shootPoint;  //transform of bullet spawn point

    // Start is called before the first frame update
    void Start()
    {
        CurrentCooldown = FireCooldown; //sets cooldown to firecooldown
    }

    // Update is called once per frame
    void Update()
    { 
            if (shootInput.action.ReadValue<bool>())    //gets headset input
            {
                if (CurrentCooldown <= 0f)      //checks if cooldown time is over
                {
                    CurrentCooldown = FireCooldown;     //resets currentcooldown
                    Shoot();
                }
            }
        CurrentCooldown -= Time.deltaTime;      //sets currentcooldown 
    }

    void Shoot()
    {
        GameObject PROJECTILE = Instantiate(projectile, shootPoint.transform);  //summons bullet at shootPoint
        Rigidbody bulletRB = GetComponent<Rigidbody>();  //gets bullets RB
        bulletRB.AddForce(Vector3.forward);  //makes the bullet move forward
    }
}
