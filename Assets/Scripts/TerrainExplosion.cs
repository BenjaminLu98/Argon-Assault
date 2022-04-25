using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainExplosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] float minExplosionDistance = 5.0f;
    [SerializeField] int explosionEndurance = 10;


    static Vector3 LastHitPosition = new Vector3(0, 0, 0);
    static int closeHitCount=0;

    // Start is called before the first frame update

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> eventList = new List<ParticleCollisionEvent>();
        int eventNum = ps.GetCollisionEvents(other, eventList);
        if(eventNum>0)
        {
            Vector3 collisionPosition = eventList[0].intersection;
            Vector3 normalRotation = eventList[0].normal;

            float distanceFromLastHit = Vector3.Distance(collisionPosition, LastHitPosition);
            
            //Explode if the distance between last explosion is far or the particle count is over the endurance
            if(distanceFromLastHit > minExplosionDistance || closeHitCount > explosionEndurance)
            {
                var explosionObj = Instantiate(explosion, collisionPosition, Quaternion.Euler(normalRotation));
                if (GameObject.Find("Explosion") != null)
                {
                    explosionObj.transform.parent = GameObject.Find("Explosion").transform;
                }
                closeHitCount = 0;
                //Debug.Log("explode"+ distanceFromLastHit);
            }
            else 
            {
                closeHitCount++;
                //Debug.Log("closeHitCount"+closeHitCount+"dist"+ distanceFromLastHit);
            }
            LastHitPosition = collisionPosition;

        }
    }
}

