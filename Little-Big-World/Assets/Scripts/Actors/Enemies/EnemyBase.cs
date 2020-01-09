using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBase : MonoBehaviour
{
    // == Character Information Variables ==
    [Header("Information")]
    [SerializeField] protected string enemyName = "";
    [SerializeField] protected Color colour = Color.white;

    // == Movement Variables ==
    [Header("Movement")]
    protected Rigidbody rb;

    // == Other Variables ==
    [Header("Other")]
    [SerializeField] protected DeathScreenUI deathScreen = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("You got caught by a " + enemyName + "!");
            deathScreen.SetMessage(gameObject.name);
            deathScreen.Show();
        }
    }
}
