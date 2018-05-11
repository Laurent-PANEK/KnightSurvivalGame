using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_attack : MonoBehaviour {

    private Vector3 _playerPos;
    private bool IsPlayer = false;
    private NavMeshAgent _nav;

	// Use this for initialization
	void Start () {
        _nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        AttackPlayer();
	}

    public void OnTriggerEnter(Collider other)
    {
        MoveToPlayer(other);
    }

    public void OnTriggerStay(Collider other)
    {
        MoveToPlayer(other);
    }

    public void OnTriggerExit(Collider other)
    {
        GetComponent<mov_enemy>().SetDestination();
        if (GetComponent<mov_enemy>().CheckAniClip("idle_normal") == false) return;

        GetComponent<Animation>().CrossFade("idle_normal", 0.0f);
        GetComponent<Animation>().CrossFadeQueued("idle_normal");
    }

    public void MoveToPlayer(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerPos = other.gameObject.GetComponent<Transform>().position;
            _nav.SetDestination(_playerPos);
            IsPlayer = true;
        }
    }

    public void AttackPlayer()
    {

        if (_nav.remainingDistance < 2 && IsPlayer)
        {
            IsPlayer = false;
            if (GetComponent<mov_enemy>().CheckAniClip("attack_short_001") == false) return;

            GetComponent<Animation>().CrossFade("attack_short_001", 0.0f);
            GetComponent<Animation>().CrossFadeQueued("idle_combat");
        }
    }

}
