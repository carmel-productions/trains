/******************************************************************************/
/*!
\file   train_movement.cs
\author Ryan Hanson
\par    email: carmel.prods@gmail.com
\brief
  Handles the movement of the player's train.
\copyright    All content © 2019 Carmel Productions, all rights reserved.
*/
/******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_movement : MonoBehaviour
{
  public Vector3 velocity = new Vector3(10,0,0);

  public float smoothing_factor = 1.0f;

  /**************************************************************************/
  /*!
    \brief 
      Updates the position of the train. Moves the train by speed units in x
      every sixtith of a second.
  */
  /**************************************************************************/
  void FixedUpdate()
  {
    Rigidbody2D body = this.GetComponent<Rigidbody2D>();
    body.velocity = Vector3.Lerp(body.velocity, velocity, smoothing_factor * Time.deltaTime); 
  }
}
