using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int Health;
    public int Score;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("score_label").GetComponent<Text>().text = "Score : " + Score;
        GameObject.Find("health_label").GetComponent<Text>().text = "Health : " + Health+ " / 1000";

    }

    public void getHit(int damage)
    {
        Health -= damage;
        if (IsDead())
        {
            GetComponent<Animator>().SetTrigger("Die");
            Destroy(gameObject, 4);
            
        }
        else
            GetComponent<Animator>().SetTrigger("Hit");
    }

    public bool IsDead()
    {
        return Health <= 0 ? true : false;
    }
}
