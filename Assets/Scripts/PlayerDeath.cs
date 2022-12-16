using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator anim;
    float waitTime = 1.5f;
    bool isDead = false;
   
    // Start is called before the first frame update
    void Start()
    { 
        anim = GetComponent<Animator>();
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            PlayerMovement.inst.speed = 0f;
            DieAn();
            Invoke(nameof(Die), 0.5f);
        }
        if (col.gameObject.tag == "EnergyRefil")
        {
            EnergyBar.instance.currentEnergy += 10;
            Dest();
        }
    }
    
    void Update()
    {
        if(isDead)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
       
    private void Die()
    {
        Destroy(this.gameObject,1f);
        isDead = true;
    }
    private void Dest()
    {
        Destroy(GameObject.FindWithTag ("EnergyRefil"));
    }
    private void DieAn()
    {
        anim.SetTrigger("Death");
    }
}
 