using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;

    public float rotationSpeed = 1f;
    public GameObject bulletPrefab;
    public GameObject EnemyPivot;
    public Transform firePoint;
    public float fireRate = 1f;
    public float nextFireTime;

    private Rigidbody rd;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();

        GameObject Temp = GameObject.FindGameObjectWithTag("Player");
        
        if(Temp != null)
        {
            player = Temp.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 5.0f)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rd.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }


        Vector3 targetDirection = (player.position - EnemyPivot.transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        EnemyPivot.transform.rotation =
             Quaternion.Lerp(EnemyPivot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        if(Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            GameObject temp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            temp.GetComponent<ProejectileMove>().launchDirection = firePoint.localRotation * Vector3.forward;
            temp.GetComponent<ProejectileMove>().projectileType = ProejectileMove.PROJECTILETYPE.ENEMY;
        }
    }
}
