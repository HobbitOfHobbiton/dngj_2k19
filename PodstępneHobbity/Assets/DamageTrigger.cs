using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private List<health> vulnerableObjectsInTriggerArea = new List<health>();

    [SerializeField]
    private int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        health vulnerable = collision.gameObject.GetComponent<health>();
        if (vulnerable != null)
        {
            vulnerableObjectsInTriggerArea.Add(vulnerable);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        health vulnerable = collision.gameObject.GetComponent<health>();
        if (vulnerable != null)
        {
            vulnerableObjectsInTriggerArea.Remove(vulnerable);
        }
    }
    
    public void ApplyDamageToAllVulnerableInRange()
    {
        health[] vuls = vulnerableObjectsInTriggerArea.ToArray();
        foreach(health vul in vuls)
        {
            if (vul != null)
            {
                vul.damageOrc(damage);
            }
        }
    }
}
