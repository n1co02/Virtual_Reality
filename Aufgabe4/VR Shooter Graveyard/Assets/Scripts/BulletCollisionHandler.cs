using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private Animator botAnimator;

    private void OnCollisionEnter(Collision collision)
    {
            // Abfrage ob eine Collision mit einer Hitbox passiert ist
            if (collision.gameObject.CompareTag("headhitbox") ||
                collision.gameObject.CompareTag("bodyhitbox") ||
                collision.gameObject.CompareTag("foothitbox"))
            {
                // Zugriff auf den Roboter über das Elternobjekt (Root-Objekt)
                GameObject robot = collision.transform.root.gameObject;
                DestroyWithAnimation(robot);

            }

            // Zerstöre das Bullet-Objekt
            // Destroy(gameObject);
        
    }

    private void DestroyWithAnimation(GameObject robot)
    {
        // führt die Animation ausa
        botAnimator = robot.GetComponent<Animator>();
        botAnimator.SetTrigger("die");
           
        // hole alle Hitboxen und deaktiviere jede
        Collider[] colliders = robot.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false; 
        }

        // zerstöre den Roboter
        Destroy(robot, 1.5f);
    }
}
