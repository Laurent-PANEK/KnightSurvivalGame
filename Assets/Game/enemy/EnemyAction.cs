using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAction : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            GetHit(collision.gameObject.GetComponent<Stats>().Damage);
        }
    }

    public void GetHit(int damage)
    {
        GetComponent<Stats>().Health -= damage;

        if (GetComponent<Stats>().IsDead())
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            if (GetComponent<mov_enemy>().CheckAniClip("dead") == false) return;

            GetComponent<Animation>().CrossFade("dead", 0.2f);
            Destroy(gameObject, 4);
            GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<PlayerStats>().Score += 100;
        }
        else
        {
            if (GetComponent<mov_enemy>().CheckAniClip("damage_001") == false) return;

            GetComponent<Animation>().CrossFade("damage_001", 0.0f);
            GetComponent<Animation>().CrossFadeQueued("idle_combat");
        }
    }

}

