using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{

    public string Type;
    private bool IsUsed = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use(GameObject player)
    {
        if (Type == null) return;
        switch (Type)
        {
            case "Heal":
                Heal(player);
                break;
            default:
                break;
        }
        IsUsed = true;
    }

    public bool HasUsed()
    {
        return IsUsed;
    }

    private void Heal(GameObject player)
    {
        Debug.Log(player.name);
        if ((player.GetComponentInParent<PlayerStats>().Health - player.GetComponentInParent<PlayerStats>().CurrentHealth) >= 100)
            player.GetComponentInParent<PlayerStats>().CurrentHealth += 100;
        else
            player.GetComponentInParent<PlayerStats>().CurrentHealth += (player.GetComponentInParent<PlayerStats>().Health - player.GetComponentInParent<PlayerStats>().CurrentHealth);
    }
}
