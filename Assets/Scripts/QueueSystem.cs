using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueSystem : MonoBehaviour
{
  public Text m_QueueText;
  public List<Passenger> m_Passengers;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void LateUpdate()
  {
    UpdateUI();
  }

  public void UpdateUI()
  {
    m_QueueText.text = "K�: " + m_Passengers.Count;
  }
}
