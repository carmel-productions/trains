using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_lifetime : MonoBehaviour
{
  public float lifetime = 1.0f;

  private float timer;
  // Start is called before the first frame update
  void Start()
  {
    timer = lifetime;
  }

  // Update is called once per frame
  void Update()
  {
    timer -= Time.deltaTime;
    if (timer <= 0)
    {
      Debug.Log("Bullet reached lifetime");
      Object.Destroy(this.gameObject);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("Bullet hit!");
    if (collision.gameObject)
    {
      if (collision.gameObject.CompareTag("Enemy"))
      {
        Destroy(this.gameObject);
      }
    }
  }
}
