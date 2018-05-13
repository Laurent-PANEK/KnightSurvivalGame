using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

    public Transform[] SpawnPos;
    public int ItemNumber;
    public GameObject[] ItemsPrefab;
    // Use this for initialization
    void Start () {
        InvokeRepeating("AddItem", 0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] ActiveItem = GameObject.FindGameObjectsWithTag("Item");
        if (ActiveItem.Length < ItemNumber)
        {
            if (!IsInvoking("AddItem"))
                InvokeRepeating("AddItem", 0.0f, 1.0f);
        }
        else
        {
            if (IsInvoking("AddItem"))
                CancelInvoke();
        }
    }

    public void AddItem()
    {
        int RandomPos = Random.Range(0, SpawnPos.Length);
        int RandomItem = Random.Range(0, ItemsPrefab.Length);
        Instantiate(ItemsPrefab[RandomItem], SpawnPos[RandomPos].position, SpawnPos[RandomPos].rotation);
    }
}
