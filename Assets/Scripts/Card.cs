using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
  private float m_startingPosX;
  private float m_startingPosY;
  public bool m_IsBeingHeld;
  // Start is called before the first frame update
  void Start()
  {

  }

  void Update()
  {
    if (m_IsBeingHeld)
    {
      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      transform.localPosition = new Vector3(mousePosition.x - m_startingPosX, mousePosition.y - m_startingPosY, 0);
    }
  }

  public void OnMouseDown()
  {
    if (Input.GetMouseButton(0))
    {
      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      m_startingPosX = mousePosition.x - transform.localPosition.x;
      m_startingPosY = mousePosition.y - transform.localPosition.y;

      m_IsBeingHeld = true;
    }
  }

  private void OnMouseUp()
  {
    m_IsBeingHeld = false;
  }
}
