using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private List<health> vulnerableObjectsInTriggerArea = new List<health>();

    [SerializeField]
    private int damage = 50;
    [SerializeField]
    float BackPozytionX = 0;

    private float StartPozytionX;
    private float timeToBack = 0;
    

    void Start()
    {
        StartPozytionX = transform.localPosition.x;
        TrigerBack();
    }

    void Update()
    {
        Debug.Log("Colider Wapon pozytion x = " + transform.localPosition.x);
        if (transform.localPosition.x != BackPozytionX)
        {
            timeToBack -= Time.deltaTime;
            if (timeToBack <= 0)
            {
                ApplyDamageToAllVulnerableInRange();
                TrigerBack();
                timeToBack = 0.01f;
            }
        }
            
    }

    public void TrigerFoword()
    {
        transform.localPosition = new Vector2(StartPozytionX, transform.localPosition.y);
    }

    public void TrigerBack()
    {
        Debug.Log("Back");
        transform.localPosition = new Vector2(BackPozytionX, transform.localPosition.y);
    }

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
