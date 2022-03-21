using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

    RaycastHit _hit;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    
    void Start(){
        if(cam == null){
            Debug.LogError("no camera");
            this.enabled = false;
        }        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
    }

    private void Shoot(){
        
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask)){
            PlayerShot(weapon.damage);
            Debug.Log(_hit.collider.name);
        }
        /*if(_hit.collider.tag == "Player"){
            Debug.Log("you hit the player");
        }*/
    }

   void PlayerShot(int damage){ // joueur touché
        if (_hit.collider.tag == "Player")
        {
            Debug.Log("the player was hitting");
            Player playerScript = _hit.collider.GetComponent<Player>();
            playerScript.TakeDamage(damage);
            if (playerScript.currentHealth==0)
            {
                Debug.Log("the player lost");
                
            }
        }

        else
        {
            Debug.Log("hit something else");
        }
    }
}
