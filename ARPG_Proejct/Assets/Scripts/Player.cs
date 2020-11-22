using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    public float speed;
    public int maxHealth;


    public Image[] hearts;

    int currentHealth;
    Animator anim;
    #endregion Variables

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;

        GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyUp(KeyCode.P))
        {
            currentHealth--;
            Debug.Log("pressing P");
        }

        GetHealth();

    }


    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            anim.SetInteger("dir", 0);
            anim.speed = 1;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            anim.SetInteger("dir", 1);
            anim.speed = 1;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            anim.SetInteger("dir", 2);
            anim.speed = 1;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetInteger("dir", 3);
            anim.speed = 1;
        }

        // if no key is pressed anim parameter direction is 0
        else
            anim.speed = 0;
    }

    void GetHealth()
    {
        for(int i = 0; i <= hearts.Length - 1; i++)
        {
            hearts[i].gameObject.SetActive(false);
        }
        for(int i =0; i<=currentHealth - 1; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }
}
