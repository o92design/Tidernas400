using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Route : MonoBehaviour
{
  public int m_TicketPrice;
  public Slider m_TicketSlider;
  public int m_MilitaryRating;
  public int m_HistoryRating;
  public int m_NatureRating;

  public List<CardHolder> m_holders = new List<CardHolder>();

  public Text m_TextMilitaryRating;
  public Text m_TextHistoryRating;
  public Text m_TextNatureRating;
  public Text m_TextTicketPrice;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    m_MilitaryRating = CalculateRating(Interest.ID.Military);
    m_HistoryRating = CalculateRating(Interest.ID.History);
    m_NatureRating = CalculateRating(Interest.ID.Nature);
  }

  public void LateUpdate()
  {
    UpdateUI();
  }

  public int CalculateRating(Interest.ID p_id)
  {
    int rating = 0;
    foreach (CardHolder holder in m_holders)
    {
      if (holder.m_Card != null)
      {
        SeaChart chart = holder.m_Card.GetComponent<SeaChart>();
        rating += chart.m_ChartData.Interest.id == p_id ? chart.m_ChartData.rating : 0;
      }
    }

    return rating;
  }

  public void UpdateTicketPrice()
  {
    m_TicketPrice = (int) m_TicketSlider.value;
  }

  public void UpdateUI()
  {
    m_TextMilitaryRating.text = "Militär: " + m_MilitaryRating + " - " + m_TicketPrice + " = " + (m_MilitaryRating - m_TicketPrice);
    m_TextHistoryRating.text = "Historia: " + m_HistoryRating + " - " + m_TicketPrice + " = " + (m_HistoryRating - m_TicketPrice);
    m_TextNatureRating.text = "Naturen: " + m_NatureRating + " - " + m_TicketPrice + " = " + (m_NatureRating - m_TicketPrice);
    m_TextTicketPrice.text = "Biljettpris: " + m_TicketPrice + " Riks";
  }
}
