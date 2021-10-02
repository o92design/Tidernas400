using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
  public Card m_Card;
  private bool m_cardOnHolder = false;
  public string m_holdTag;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(m_Card != null && m_Card.m_IsBeingHeld)
    {
      m_Card.transform.parent = null;
    }

    if (m_Card != null && !m_cardOnHolder)
    {
      if (m_Card.m_IsBeingHeld)
      {
        m_Card.transform.parent = null;
        m_Card = null;
      }
    }
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.tag == m_holdTag)
    {
      Card card = collision.GetComponent<Card>();
      Debug.Log("Card is on Holder");
      if (m_Card == null)
      {
        if (!card.m_IsBeingHeld)
        {
          m_Card = card;
          card.transform.parent = transform;
          card.transform.localPosition = new Vector3();
          m_cardOnHolder = true;
        }
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.tag == m_holdTag)
    {
      m_cardOnHolder = false;
    }
  }
}
