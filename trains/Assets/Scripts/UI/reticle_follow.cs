/******************************************************************************/
/*!
\file   reticle_follow.cs
\author Ryan Hanson
\par    email: carmel.prods@gmail.com
\brief
  Moves the aiming reticle to the position of the mouse cursor
\copyright    All content © 2019 Carmel Productions, all rights reserved.
*/
/******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticle_follow : MonoBehaviour
{
  /**************************************************************************/
  /*!
    \brief 
      Hides the mouse cursor
  */
  /**************************************************************************/
  void Start()
  {
    Cursor.visible = false;
  }

  /**************************************************************************/
  /*!
    \brief 
      Moves the reticle to the position of the mouse cursor
  */
  /**************************************************************************/
  void Update()
  {
    transform.position = Input.mousePosition;
  }
}
