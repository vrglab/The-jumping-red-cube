using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private ShakeBehivour sb;
    public ParticleSystem ps;
    public bool isDead;
    public float speed = 10f;
    public GameObject deathPanel;
    private Rigidbody2D rg2d;
    private SpriteRenderer sr;
    public float jumpHeight;
    public bool isJumping = false;
    public AudioSource JumpSound;
    public AudioSource DeathSound;


    // Start is called before the first frame update
    void Start()
    {
        sb = GameObject.Find("Main Camera").GetComponent<ShakeBehivour>();
        rg2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) // both conditions can be in the same branch
        {
            if(isJumping == false)
            {
                rg2d.AddForce(Vector2.up * jumpHeight , ForceMode2D.Impulse); // you need a reference to the RigidBody2D component
                isJumping = true;
                if(!JumpSound.isPlaying)
                {
                    JumpSound.Play();
                }
            }

            
            print("jumped");
        }
        if(Input.GetKey(KeyCode.D))
        {
            rg2d.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground") // GameObject is a type, gameObject is the property
        {
            isJumping = false;
        }
    }



public void Death()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
        speed = 0f;
        if(!ps.isPlaying)
        {
            ps.Play();
        }
        sb.TriggerShake();
        if(!DeathSound.isPlaying)
        {
            DeathSound.Play();
        }
        this.enabled = false;
        deathPanel.SetActive(true);
        isDead = true;
    }

    public bool IsPlayerDead()
    {
        if(isDead == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void reset()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
