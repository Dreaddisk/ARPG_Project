using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    public float speed;
    public float thrustPower;
    public int maxHealth;

    public GameObject sword;
    public Image[] hearts;
    public bool canMove;

    int currentHealth;
    Animator anim;
    #endregion Variables

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;

        GetHealth();

        canMove = true;
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
        if (!canMove)
            return;
        #region Player_Movement_Direction
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
        #endregion

        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerAttack();
        }
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

    void PlayerAttack()
    {
        canMove = false;
        GameObject newSword = Instantiate(sword, transform.position, 
            sword.transform.rotation);



        #region Sword_Direction

        int swordDir = anim.GetInteger("dir");
        if (swordDir == 0)
        {
            newSword.transform.Rotate(0, 0, 0);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrustPower * Time.deltaTime);
        }

        else if (swordDir == 1)
        {
            newSword.transform.Rotate(0, 0, 180);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.down * thrustPower * Time.deltaTime);
        }

        else if (swordDir == 2)
        {
            newSword.transform.Rotate(0, 0, 90);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.left * thrustPower * Time.deltaTime);
        }

        else if (swordDir == 3)
        {
            newSword.transform.Rotate(0, 0, -90);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrustPower * Time.deltaTime);
        }


        #endregion Sword_Diretion
    }
}
