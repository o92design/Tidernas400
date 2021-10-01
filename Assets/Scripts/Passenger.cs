using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum FirstNameList
{
  
}

public enum LastNameList
{

}

[Serializable]
public struct PassengerData
{
  public String Name;
  public float Money;

  [Range(1, 5)]
  public int Rating;
  public bool VIP;
}

public class Passenger : MonoBehaviour
{
  public PassengerData m_PassengerData;

  // Start is called before the first frame update
  void Start()
  {
    name = m_PassengerData.Name;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
