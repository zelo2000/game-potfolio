using Assets.Scripts.Models;
using UnityEngine;

// TODO: Move TowerBlueprint to list and create menu items automatically
public class Shop : MonoBehaviour
{
    public TowerBlueprint StandartTower;
    public TowerBlueprint MissleLauncher;
    public TowerBlueprint LaserBeamer;

    private BuildManager _buildManager;

    public void SelectStandartTower()
    {
        _buildManager.TowerToBuild = StandartTower;
    }

    public void SelectMissileTower()
    {
        _buildManager.TowerToBuild = MissleLauncher;
    }

    public void SelectLaserBeamer()
    {
        _buildManager.TowerToBuild = LaserBeamer;
    }

    private void Start()
    {
        _buildManager = BuildManager.Instanse;
    }
}
