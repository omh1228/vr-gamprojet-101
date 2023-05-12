using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rd;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 5.0f)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rd.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
    }
}
