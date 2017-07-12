using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
  [SerializeField] private Sprite m_RedReticle;
  [SerializeField] private Sprite m_YellowReticle;
  [SerializeField] private Sprite m_BlueReticle;
  [SerializeField] private Image m_Reticle;
  [SerializeField] private Text m_AmmoText;
  [SerializeField] private Text m_HealthText;
  [SerializeField] private Text m_ArmorText;
  [SerializeField] private Text m_ScoreText;
  [SerializeField] private Text m_PickupText;
  [SerializeField] private Text m_WaveText;
  [SerializeField] private Text m_EnemyText;
  [SerializeField] private Text m_WaveClearText;
  [SerializeField] private Text m_NewWaveText;
  [SerializeField] private Player m_Player;

  public void UpdateReticle() {
    switch (GunEquipper.ActiveWeaponType) {
      case Constants.Pistol:
        m_Reticle.sprite = m_RedReticle;
        break;
      case Constants.AssaultRifle:
        m_Reticle.sprite = m_BlueReticle;
        break;
      case Constants.Shotgun:
        m_Reticle.sprite = m_YellowReticle;
        break;
      default:
        return;
    }
  }

  private void Start() {
    SetArmorText(m_Player.Armor);
    SetHealthText(m_Player.Health);
  }

  public void SetArmorText(int armor) {
    m_ArmorText.text = "Armor: " + armor;
  }

  public void SetHealthText(int health) {
    m_HealthText.text = "Health: " + health;
  }

  public void SetAmmoText(int ammo) {
    m_AmmoText.text = "Ammo: " + ammo;
  }

  public void SetScoreText(int score) {
    m_ScoreText.text = string.Format("{0}", score);
  }

  public void SetWaveText(int time) {
    m_WaveText.text = "Next Wave: " + time;
  }

  public void SetEnemyText(int enemies) {
    m_EnemyText.text = "Enemies: " + enemies;
  }

  public void ShowWaveClearBonus() {
    m_WaveClearText.GetComponent<Text>().enabled = true;
    StartCoroutine(HideWaveClearBonus());
  }

  private IEnumerator HideWaveClearBonus() {
    yield return new WaitForSeconds(4);
    m_WaveClearText.GetComponent<Text>().enabled = false;
  }

  public void SetPickupText(string text) {
    m_PickupText.GetComponent<Text>().enabled = true;
    m_PickupText.text = text;
    StopCoroutine(HidePickupText());
    StartCoroutine(HidePickupText());
  }

  private IEnumerator HidePickupText() {
    yield return new WaitForSeconds(4);
    m_PickupText.GetComponent<Text>().enabled = false;
  }

  public void ShowNewWaveText() {
    StartCoroutine(HideNewWaveText());
    m_NewWaveText.GetComponent<Text>().enabled = true;
  }

  private IEnumerator HideNewWaveText() {
    yield return new WaitForSeconds(4);
    m_NewWaveText.GetComponent<Text>().enabled = false;
  }
  
}