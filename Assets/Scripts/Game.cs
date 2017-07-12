using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
  public GameUI GameUi;
  public GameObject Player;
  public int Score;
  public int WaveCountdown;
  public bool IsGameOver;
  public int EnemiesLeft;

  [SerializeField] private List<RobotSpawn> Spawns;
  private static Game _singleton;

  private void Start() {
    _singleton = this;
    StartCoroutine(IncreaseScoreEachSecond());
    IsGameOver = false;
    Time.timeScale = 1;
    WaveCountdown = 30;
    EnemiesLeft = 0;
    StartCoroutine(UpdateWaveTimer());
    SpawnRobots();
  }

  private void SpawnRobots() {
    foreach (var spawn in Spawns) {
      spawn.SpawnRobot();
      EnemiesLeft++;
    }
    GameUi.SetEnemyText(EnemiesLeft);
  }

  private IEnumerator UpdateWaveTimer() {
    while (!IsGameOver) {
      yield return new WaitForSeconds(1);
      WaveCountdown--;
      GameUi.SetWaveText(WaveCountdown);

      if (WaveCountdown == 0) {
        SpawnRobots();
        WaveCountdown = 30;
        GameUi.ShowNewWaveText();
      }
    }
  }

  public static void RemoveEnemy() {
    _singleton.EnemiesLeft--;
    _singleton.GameUi.SetEnemyText(_singleton.EnemiesLeft);

    if (_singleton.EnemiesLeft == 0) {
      _singleton.Score += 50;
      _singleton.GameUi.ShowWaveClearBonus();
    }
  }

  public void AddRobotKillToScore() {
    Score += 10;
    GameUi.SetScoreText(Score);
  }

  private IEnumerator IncreaseScoreEachSecond() {
    while (!IsGameOver) {
      yield return new WaitForSeconds(1);
      Score += 1;
      GameUi.SetScoreText(Score);
    }
  }
}