using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int n;
    [SerializeField]
    private int maxHealth = 100; 
    public bool CanAttack = false;
    public Animator anim;    

    public RectTransform healthbar;

    public int currentHealth;
    internal static readonly object singleton;

    private void Start(){
        anim = GetComponent<Animator>();   
    }

    private void Awake(){
        SetDefaults();
    }

    public void SetDefaults(){
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;
        Debug.Log("Le joueur a maintenant :"+ currentHealth+ " points de vie");
        CanAttack = true;
        if(currentHealth == 0){   
            anim.SetBool("Dead", true);
            CanAttack = false;
            Destroy(gameObject, 2);
        }
        healthbar.sizeDelta = new Vector2(currentHealth, healthbar.sizeDelta.y);
    }
}
