using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    #region Variables
    private float timer = .15f;
    private float specialTimer = 1f;

    //[SerializeField] private float destroyCountdown;

    public bool special;
    #endregion

    // Use this for initialization
    void Start()
    {
        special = true;
    
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("attackDir", 5);
        }
        if(!special)
        if(timer <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
            Destroy(this.gameObject);
        }

        specialTimer -= Time.deltaTime;

        if(specialTimer <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
            Destroy(gameObject);
        }

    }
}
