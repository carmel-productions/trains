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
  public GameObject target; // Camera anchor point on the train
  public float smooth_time = 0.3f; // smooth time for smoothing camera
  public float x_offset = 0.0f; // x offset for camera
  public float y_offset = 0.0f; // y offset for camera
  public float cam_distance = -10.0f; // distance the camera should be from the target
  public float cam_start_dist = -100.0f; // starting distance from the target

  public static float cam_dist; // distance of camera to target

  private Vector3 vel = Vector3.zero;

  /**************************************************************************/
  /*!
    \brief 
      Starts the camera zoomed out so it can smoothly zoom in at the beginning.
  */
  /**************************************************************************/
  void Start()
  {
    Vector3 pos = transform.position;
    pos.z = cam_start_dist;
    transform.position = pos;
  }

  /**************************************************************************/
  /*!
    \brief 
      Updates the position of the main cam to follow the train. Is called
      after the normal Update function
  */
  /**************************************************************************/
  void LateUpdate()
  {
    if(target)
    {
      cam_dist = transform.position.z; 

      Vector3 dest = target.transform.position;

      dest.x += x_offset;
      dest.y += y_offset;
      dest.z = cam_distance;
      transform.position = Vector3.SmoothDamp(transform.position, dest, ref vel, smooth_time);
    }
  }
}
