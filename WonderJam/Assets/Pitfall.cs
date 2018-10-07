using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour {

    public Transform respawnPoint;
    public float pitDamage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.gameObject.transform.position = new Vector3(respawnPoint.position.x, respawnPoint.position.y);
        UnitHealth health = collision.collider.GetComponent<UnitHealth>();
        if (health)
        {
            health.Damage(pitDamage);
        }
    }
}
