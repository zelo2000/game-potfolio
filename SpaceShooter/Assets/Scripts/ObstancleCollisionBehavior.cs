using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstancleCollisionBehavior : MonoBehaviour
{
    public GameObject Effect;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<GameControler>().AddScore();
            var effect = Instantiate(Effect, transform.position, transform.rotation);
            Destroy(effect, 3.0f);
        }
    }
}
