using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_fire : MonoBehaviour
{
  public GameObject projectile; // the projectile being fired from the cannon

  public Vector3 bullet_velocity = new Vector3(30,30,0);
  
  public float firerate = 1.0f;
  private float cooldown = 1.0f; // time until next shot allowed 1.0f means you can fire once per second

  public static bool firing = false;

  void Fire()
  {
    GameObject nobject = Instantiate(projectile);

    // spawn a bullet
    nobject.GetComponent<SpriteRenderer>().enabled = true;
    Rigidbody2D body = nobject.GetComponent<Rigidbody2D>();
    nobject.AddComponent<bullet_lifetime>();
    nobject.transform.position = transform.position;
    nobject.transform.rotation = transform.rotation;
    // calculate the velocity
    Vector3 velocity = bullet_velocity;
    velocity = transform.rotation * velocity;
    body.velocity = velocity;
    nobject.GetComponent<bullet_lifetime>().enabled = true;
    Debug.Log("Firing bullet");
  }

  void Start()
  {
    cooldown = firerate;
  }

  // Update is called once per frame
  void Update()
  {
    firing = (Input.GetKey(KeyCode.Mouse0)) ? true : false;

    cooldown -= Time.deltaTime;

    // if cooldown is below 0, set it to zero to avoid any number that don't fit if the
    // player never shoots
    cooldown = (cooldown < 0.0f) ? 0.0f : cooldown;

    if(cooldown <= 0.0f && firing)
    {
      Fire();
      cooldown = firerate;
    }
  }
}
