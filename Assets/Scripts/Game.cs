using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
  public int EnemiesLeft;

  [SerializeField] private List<RobotSpawn> Spawns;
  private static Game _singleton;

  private void Start() {
    _singleton = this;
    SpawnRobots();
  }

  private void SpawnRobots() {
    foreach (var spawn in Spawns) {
      spawn.SpawnRobot();
      EnemiesLeft++;
    }
  }
}