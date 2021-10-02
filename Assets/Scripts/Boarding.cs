using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boarding : MonoBehaviour
{
  public QueueSystem m_Queue;
  public Route m_route;
  public CardHolder m_ShipHolder;

  public void Board()
  {
    if (m_route != null && m_ShipHolder.m_Card != null)
    {
      int militaryRating = m_route.m_MilitaryRating;
      int historyRating = m_route.m_HistoryRating;
      int natureRating = m_route.m_NatureRating;

      Ship ship = m_ShipHolder.m_Card.GetComponent<Ship>();

      int waitingCount = m_Queue.m_Passengers.Count;
      Passenger[] waitingPassengers = new Passenger[waitingCount];

      for(int index = 0; index < waitingCount; ++index)
      {
        waitingPassengers[index] = m_Queue.m_Passengers[index];
      }

      foreach (Passenger inLine in waitingPassengers)
      {
        if (ship.m_ShipData.Passengers.Count < ship.m_ShipData.PassengerCapacity)
        {
          inLine.m_PassengerData.Rating = Random.Range(2, 12);
          int interestRating = 0;

          switch (inLine.m_PassengerData.Interest.id)
          {
            case Interest.ID.Military:
              interestRating = militaryRating;
              break;

            case Interest.ID.History:
              interestRating = historyRating;
              break;

            case Interest.ID.Nature:
              interestRating = natureRating;
              break;
          }

          interestRating -= m_route.m_TicketPrice;
          if (inLine.m_PassengerData.Rating <= interestRating)
          {
            Debug.Log(inLine.m_PassengerData.Name + " boarded the ship due to interest of " + inLine.m_PassengerData.Interest.interest + " " + inLine.m_PassengerData.Rating + " / " + interestRating);

            int shipPassengers = ship.m_ShipData.Passengers.Count;
            inLine.transform.parent = ship.transform;
            Vector2 position = shipPassengers == 0 ? new Vector2() : ship.m_ShipData.Passengers[shipPassengers - 1].transform.localPosition;
            inLine.transform.localPosition = shipPassengers == 0 ? position : position - new Vector2(0, 0.35f);

            ship.m_ShipData.Passengers.Add(inLine);
            m_Queue.m_Passengers.Remove(inLine);
          }
          else
          {
            Debug.Log(inLine.m_PassengerData.Name + " didn't want to go on the route due to rating: " + inLine.m_PassengerData.Rating + " / " + interestRating);
          }
        }
      }
    }
    else
    {
      Debug.Log("There is no ship or route assigned!");
    }
  }
}
