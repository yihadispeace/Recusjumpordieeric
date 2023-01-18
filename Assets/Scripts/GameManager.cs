using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioManager sfxManager;
    private Player_movement knight;
    private Animator staranimator;
  

    public GameObject victoria;
    public GameObject derrota;
    int contestrellas;

    public Text numstars;
    
   
    // Start is called before the first frame update
    void Awake()
    {

        sfxManager = GameObject.Find("SFXManager").GetComponent<AudioManager>();
        knight = GameObject.Find("knight").GetComponent<Player_movement>();
        
        
    }
    void Start() 
    {

        victoria.SetActive(false);
        derrota.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void cogerestrellas(GameObject estrella, GameObject character)
    {

        staranimator = estrella.GetComponent<Animator>();        

        contestrellas = contestrellas + 1;
        Debug.Log("Conseguiste " +contestrellas+ " estrellas");

        if(contestrellas == 10)
        {

            ganar(character);
            sfxManager.victorysound();
            Invoke("MainMenu", 5);

        }
        
        Destroy(estrella.gameObject);
        numstars.text = contestrellas.ToString();
        sfxManager.catchastar();


    }
    public void muerte(GameObject character)
    {

        derrota.SetActive(true);
        sfxManager.losesound();
        Destroy(character, 4f);
        Invoke("MainMenu", 5);

    }

    

    void ganar(GameObject character)
    {

        victoria.SetActive(true);
        Destroy(character, 0.3f);

        
    }  
}
