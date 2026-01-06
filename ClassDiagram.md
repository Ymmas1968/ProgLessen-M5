```mermaid

classDiagram
  %% Player scripts (uit subfolder)
  class CameraMovement {
    - float speed
    - Transform target
    + void Update()
    + void FollowTarget()
  }
  class CurrencyManager {
    - int currencyAmount
    - Text currencyText
    + void AddCurrency(int amount)
    + void SpendCurrency(int cost)
    + void UpdateUI()
  }
  class Hotbar {
    - GameObject[] towerPrefabs
    - int selectedIndex
    + void SelectTower(int index)
    + void PlaceSelectedTower()
  }
  class PlacingTowers {
    - LayerMask groundLayer
    - GameObject towerPrefab
    - bool isPlacing
    + void StartPlacing()
    + void PlaceTowerAtMouse()
    + void CancelPlacing()
  }
  class PlayButton {
    - Button buttonComponent
    + void OnClick()
    + void StartGame()
  }
  class PlayerHP {
    - int maxHP
    - int currentHP
    - Slider hpSlider
    + void TakeDamage(int damage)
    + void UpdateHPUI()
    + void GameOver()
  }
  class Replay {
    - SceneManager sceneManager
    + void RestartLevel()
    + void ReloadScene()
  }
  class Sceneloader {
    - string sceneName
    + void LoadScene(string name)
    + void LoadMainMenu()
  }
  class Switcher {
    - GameObject[] uiPanels
    + void SwitchToPanel(int index)
    + void ToggleMenu()
  }

  %% Tower script (uit subfolder)
  class TowerShooting {
    - float range
    - float fireRate
    - int damage
    - GameObject bulletPrefab
    - Transform targetEnemy
    + void UpdateTarget()
    + void Shoot()
    + void CheckRange()
  }

  %% Enemy scripts (uit subfolder)
  class EnemyHealth {
    - int maxHealth
    - int currentHealth
    - EnemyReward reward
    + void TakeDamage(int amount)
    + void Die()
    + void OnDeath()
  }
  class EnemyWaves {
    - int currentWave
    - GameObject[] enemyPrefabs
    - float spawnDelay
    - WayPointManager waypointManager
    + void StartWave(int waveNumber)
    + void SpawnEnemy(GameObject prefab)
    + void EndWave()
  }
  class EnemyReward {
    - int goldReward
    - CurrencyManager currency
    + void GiveReward()
    + void AddToPlayerCurrency()
  }
  class PathFollower {
    - float moveSpeed
    - WayPointManager waypoints
    - int currentWaypointIndex
    + void Update()
    + void MoveToNextWaypoint()
    + void FollowPath()
  }
  class WayPointManager {
    - Transform[] waypoints
    + Transform GetNextWaypoint(int index)
    + int GetWaypointCount()
    + void ResetPath()
  }

  %% Relaties (gebaseerd op typische tower defense logica uit de repo-structuur)
  PlacingTowers --> TowerShooting : places and initializes
  TowerShooting --> EnemyHealth : targets and damages
  EnemyWaves --> PathFollower : spawns enemies that follow
  PathFollower --> WayPointManager : uses for navigation
  EnemyHealth --> EnemyReward : triggers on death
  EnemyReward --> CurrencyManager : adds to player currency
  PlayerHP --> EnemyHealth : damaged by (if enemy reaches end)
  Hotbar --> PlacingTowers : selects tower for placing
  CameraMovement --> PlayerHP : follows player view
  Sceneloader --> Replay : loads scenes for restart
  Switcher --> PlayButton : switches UI states