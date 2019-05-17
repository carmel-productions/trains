/******************************************************************************/
/*!
\file   train_follow.cs
\author Ryan Hanson
\par    email: carmel.prods@gmail.com
\brief
  Moves the main camera to follow the train
\copyright    All content © 2019 Carmel Productions, all rights reserved.
*/
/******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_follow : MonoBehaviour
{
  public GameObject train; // Camera anchor point on the train
  public Camera cam;
  public float damp_time = 0.15f;
  public float x_offset = 0.0f;
  public float y_offset = 0.0f;
  public float cam_distance = -10.0f;

  private Vector3 vel = Vector3.zero;

  /**************************************************************************/
  /*!
    \brief 
      Updates the position of the main cam to follow the train. Is called
      after the normal Update function
  */
  /**************************************************************************/
  void FixedUpdate()
  {
    if(train)
    { 
      Vector3 train_pos = cam.WorldToViewportPoint(train.transform.position);
      Vector3 pos_delta = train.transform.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, train_pos.z));
      Vector3 dest = transform.position + pos_delta;
      Vector3 n_pos = Vector3.SmoothDamp(transform.position, dest, ref vel, damp_time);
      n_pos.x += x_offset;
      n_pos.y += y_offset;
      n_pos.z = cam_distance;
      transform.position = n_pos;
    }
  }
}
