using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_fire : MonoBehaviour
{
  public GameObject projectile; // the projectile being fired from the cannon

  public float firerate = 1.0f;

  public static bool firing = false;

  private float cooldown = 1.0f; // time until next shot allowed 1.0f means you can fire once per second

  void Fire()
  {
    // spawn a bullet
    GameObject nobject = GameObject.Instantiate(projectile);
    nobject.GetComponent<MeshRenderer>().enabled = true;
    Rigidbody body = nobject.GetComponent<Rigidbody>();
    // calculate the velocity
    Vector3 velocity = new Vector3(30, 30, 0);
    velocity = transform.rotation * velocity;
    body.velocity = velocity;
  }

  void Start()
  {
    cooldown = firerate;
  }

  // Update is called once per frame
  void Update()
  {
    // keep the flyweight from moving away
    projectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
    

    firing = (Input.GetKeyDown(KeyCode.Mouse0)) ? true : false;

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
