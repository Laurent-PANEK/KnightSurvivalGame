using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mov_enemy : MonoBehaviour {

    public Transform[] Destinations;

	// Use this for initialization
	void Start () {
        SetDestination();
	}
	
	// Update is called once per frame
	void Update () {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        if(nav.remainingDistance < 1)
        {
            SetDestination();
        }

    }

    public void SetDestination()
    {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        int r = Random.Range(0, Destinations.Length);
        nav.SetDestination(Destinations[r].position);
    }

    public bool CheckAniClip(string clipname)
    {
        if (this.GetComponent<Animation>().GetClip(clipname) == null)
            return false;
        else if (this.GetComponent<Animation>().GetClip(clipname) != null)
            return true;

        return false;
    }
}
