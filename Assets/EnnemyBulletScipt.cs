using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBulletScipt : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public float force; //la vitesse de la bullet
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot  = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
