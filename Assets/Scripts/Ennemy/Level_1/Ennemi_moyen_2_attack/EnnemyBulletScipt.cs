using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBulletScipt : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    private Rigidbody rb;
    public float force; //la vitesse de la bullets

    // Start is called before the first frame update
    void Start()
    {
        bullet = GameObject.Find("PF_fleche");
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //applydamage 
            Debug.Log("bullet touché");
            Destroy(bullet);
        }
    }

}
