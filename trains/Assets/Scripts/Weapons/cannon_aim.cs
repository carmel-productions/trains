/******************************************************************************/
/*!
\file   cannon_aim.cs
\author Ryan Hanson
\par    email: carmel.prods@gmail.com
\brief
  Rotates the cannon to aim at the reticle
\copyright    All content © 2019 Carmel Productions, all rights reserved.
*/
/******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_aim : MonoBehaviour
{
  public float rotate_speed = 10.0f;

  public GameObject pivot;

  private Quaternion look_rotation_;

  /**************************************************************************/
  /*!
    \brief 
      Starts the cannon out by aiming directly upwards
  */
  /**************************************************************************/
  void Start()
  {
    transform.rotation = new Quaternion(0, 0, 0, 1);
  }

  /**************************************************************************/
  /*!
    \brief 
      Rotates the cannon to point at the reticle
  */
  /**************************************************************************/
  void Update()
  {
    Vector3 mouse_pos = Input.mousePosition;
    mouse_pos.z = train_follow.cam_dist; // get dist of camera to object

    Vector3 cannon_pos = Camera.main.WorldToScreenPoint(transform.position);
    mouse_pos.x -= cannon_pos.x;
    mouse_pos.y -= cannon_pos.y;
    float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
    angle += 90.0f; // add 90 degrees to point end of cannon rectangle at reticle
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
  }
}
