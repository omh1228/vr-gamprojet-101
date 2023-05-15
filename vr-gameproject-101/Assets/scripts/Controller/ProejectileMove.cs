using UnityEngine;

public class ProejectileMove : MonoBehaviour
{
    public enum PROJECTILETYPE
    {
        PLAYER,
        ENEMY
    }
    
    public Vector3 launchDirection;
    public PROJECTILETYPE projectileType = PROJECTILETYPE.PLAYER;

    // private void OnCollisionEnter(Collision collision)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "Monster")
        {
            collision.gameObject.GetComponent<MonsterController>().Damanged(1);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Monster" && projectileType == PROJECTILETYPE.PLAYER)
        {
            other.gameObject.GetComponent<MonsterController>().Damanged(1);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player" && projectileType == PROJECTILETYPE.ENEMY)
        {
            
            other.gameObject.GetComponent<PlayerController>().Damanged(1);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        float moveAmount = 3 * Time.fixedDeltaTime;

        transform.Translate(launchDirection * moveAmount);
    }
}
