using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferWaitingPerson : MonoBehaviour
{
  public QueueSystem m_lineTwo;
  public QueueSystem m_mainLine;

  public void Start()
  {
    m_lineTwo = GetComponent<QueueSystem>();
  }

  public void TransferPerson(Vector2 p_position)
  {
    if (m_mainLine.m_Passengers.Count < m_mainLine.m_MaxInLine)
    {
      Passenger waiting = m_lineTwo.m_Passengers[0];
      m_lineTwo.m_Passengers.Remove(waiting);
      waiting.transform.parent = m_mainLine.transform;
      waiting.transform.position = p_position;
    }
  }
}
