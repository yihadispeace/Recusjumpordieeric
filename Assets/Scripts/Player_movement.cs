using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    public float speed = 5.5f;
    public float jumpforce = 2f;
    private float horizontal;
    private Transform playerTransform;
    private Rigidbody2D rb;
    public Animator animatronix;
    public GameManager gamemanager;
    private AudioManager sfxManager;
  
    




    private void Awake() {
        
        rb = GetComponent<Rigidbody2D>();
        animatronix = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<AudioManager>();
       
        


    }
 
    //Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        
         if (horizontal == 1)
        {   
            playerTransform.rotation = Quaternion.Euler(0, 0, 0);
            animatronix.SetBool("run", true);
        }      
        else if (horizontal == -1)
        {
            playerTransform.rotation = Quaternion.Euler(0, 180, 0);
            animatronix.SetBool("run", true);
        }
        else 
        {
            animatronix.SetBool("run", false);
        }

        if(Input.GetButtonDown("Jump") && groundchecker.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            animatronix.SetBool("jump", true);
        }
        
        
    }
     void FixedUpdate() {

        
        
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);    

    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.gameObject.layer == 7)
        {

            

            sfxManager.deathcharacter();
            sfxManager.losesound();
            gamemanager.muerte(this.gameObject);

        }
         if(other.gameObject.layer == 8)
        {
            
           
            gamemanager.cogerestrellas(other.gameObject, this.gameObject);
            

        }
        
    }  
    

        
    

    
    
   
} 