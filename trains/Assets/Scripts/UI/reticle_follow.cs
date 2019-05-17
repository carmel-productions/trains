using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticle_follow : MonoBehaviour
{
  // Update is called once per frame
  void Update()
  {
    transform.position = Input.mousePosition;
  }
}
