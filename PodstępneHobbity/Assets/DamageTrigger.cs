using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private List<health> vulnerableObjectsInTriggerArea = new List<health>();

    [SerializeField]
    private int damage = 50;

    private void OnAnimatorIK(int layerIndex)
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
