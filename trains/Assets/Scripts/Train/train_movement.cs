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
  public Vector3 velocity = new Vector3(1,0,0);

  /**************************************************************************/
  /*!
    \brief 
      Updates the position of the train. Moves the train by speed units in x
      every sixtith of a second.
  */
  /**************************************************************************/
  void FixedUpdate()
  {
    Rigidbody body = this.GetComponentInParent<Rigidbody>();
    body.velocity = velocity;
  }
}
