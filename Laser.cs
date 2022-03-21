using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Laser : MonoBehaviour {
    LineRenderer line;
    RaycastHit hit;
    public float weaponRange;
    Player player;

    void Start (){

        line = gameObject.GetComponent<LineRenderer>(); 
        line.enabled = false; //initialise le laser à faux
        Cursor.lockState = CursorLockMode.Locked;  
    }
 
    void Update (){
        if (Input.GetButtonDown("Fire1")) 
        {
            StopCoroutine("FireLaser"); 
            StartCoroutine("FireLaser"); 
        }
    }

    IEnumerator FireLaser(){
        line.enabled = true;
        if(Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward); 
            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out hit, weaponRange)) 
            {
                line.SetPosition(1, hit.point); 
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(5)); 
            }
            yield return null;
        }
        line.enabled = false; 
    }
}