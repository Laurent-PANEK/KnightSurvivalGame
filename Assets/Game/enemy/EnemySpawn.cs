using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Transform[] SpawnPos;
    public int EnemyNumber;
    public GameObject EnemyPrefab;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("AddEnemy", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] ActiveEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (ActiveEnemy.Length < EnemyNumber)
        {
            if (!IsInvoking("AddEnemy"))
                InvokeRepeating("AddEnemy", 2.0f, 2.0f);
        }
        else
        {
            if (IsInvoking("AddEnemy"))
                CancelInvoke();
        }

    }

    public void AddEnemy()
    {
        int r = Random.Range(0, SpawnPos.Length);
        Instantiate(EnemyPrefab, SpawnPos[r].position, SpawnPos[r].rotation);
    }
}
