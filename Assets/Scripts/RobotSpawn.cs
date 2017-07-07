using System.Collections.Generic;
using UnityEngine;

public class RobotSpawn : MonoBehaviour {
  [SerializeField] private List<GameObject> m_Robots;

  private int m_TimesSpawned;
  private int m_HealthBonus = 0;

  public void SpawnRobot() {
    m_TimesSpawned++;
    m_HealthBonus += 1 * m_TimesSpawned;
    var robot = Instantiate(m_Robots[Random.Range(0, m_Robots.Count)]);
    robot.transform.position = transform.position;
    robot.GetComponent<Robot>().Health += m_HealthBonus;
  }

}
