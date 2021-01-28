using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksTrigger : MonoBehaviour
{
    private Collider col;
    private List<GameObject> rocks = new List<GameObject>();

    private void Awake()
    {
        col = GetComponent<Collider>();    
        for(int i = 0; i < transform.childCount; i++)
        {
            rocks.Add(transform.GetChild(i).gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Release rocks
            col.enabled = false;
            StartCoroutine(RocksFalling());
        }
    }

    IEnumerator RocksFalling()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < rocks.Count; i++)
        {
            rocks[i].SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
