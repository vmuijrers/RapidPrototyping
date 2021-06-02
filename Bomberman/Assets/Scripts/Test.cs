using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public GameObject particlePrefab;
    public AudioClip explodeSound;

    public Text UIText;

    public int damage = 10;
    public float explodeRadius = 3;
    public float timer = 3f;

    private void Start()
    {
        StartCoroutine(SetTimer(timer));
    }
    
    IEnumerator SetTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        //Collider[] results = Physics.OverlapSphere(transform.position, explodeRadius);
        //foreach(Collider col in results)
        //{
        //    Health health = col.GetComponent<Health>();
        //    if (health != null)
        //    {
        //        health.TakeDamage(damage);
        //    }
        //}
        Debug.Log("Boom!");
        //Spawn Particle

        //Update UI
        //Spawn Audio boom
        Destroy(gameObject);
        

    }

}
