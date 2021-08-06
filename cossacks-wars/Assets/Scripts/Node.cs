using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Color NotEnoughMoneyColor;
    public Vector3 PositionOffset;

    [HideInInspector]
    public GameObject CurrentTower;
    [HideInInspector]
    public TowerBlueprint CurrentTowerBlueprint;
    [HideInInspector]
    public int UpgradeIndex = 0;

    private Renderer _renderer;
    private Color _startColor;
    private BuildManager _buildManager;
    private PlayerStats _playerStats;

    //
    // Custom Functions
    //
    public Vector3 GetBuildPosition()
    {
        return transform.position + PositionOffset;
    }

    public void ResetColor()
    {
        _renderer.material.color = _startColor;
    }

    private void BuildTower(TowerBlueprint towerBlueprint)
    {
        if (_playerStats.GetMoney() < towerBlueprint.Build.Cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        _playerStats.ReduceMoney(towerBlueprint.Build.Cost);

        var buildPosition = GetBuildPosition();
        var turret = Instantiate(towerBlueprint.Build.Prefab, buildPosition, Quaternion.identity);
        CurrentTower = turret;
        CurrentTowerBlueprint = towerBlueprint;

        ResetColor();

        var effect = Instantiate(towerBlueprint.Build.Effect, buildPosition, Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTower()
    {
        var upgrade = CurrentTowerBlueprint.Upgrades[UpgradeIndex];
        if (_playerStats.GetMoney() < upgrade.Cost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        _playerStats.ReduceMoney(upgrade.Cost);

        // Remove old tower
        Destroy(CurrentTower);

        // Build new tower
        var buildPosition = GetBuildPosition();
        var turret = Instantiate(upgrade.Prefab, buildPosition, Quaternion.identity);
        CurrentTower = turret;

        ResetColor();

        var effect = Instantiate(upgrade.Effect, buildPosition, Quaternion.identity);
        Destroy(effect, 5f);

        UpgradeIndex++;
    }

    public void SellTower()
    {
        _playerStats.IncreaseMoney(CurrentTowerBlueprint.GetSellCost(UpgradeIndex));

        var effect = Instantiate(CurrentTowerBlueprint.SellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(CurrentTower);
        CurrentTowerBlueprint = null;
    }

    //
    // Unity Functions
    //
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;

        _buildManager = BuildManager.Instanse;
        _playerStats = PlayerStats.Instanse;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (CurrentTower != null)
        {
            _buildManager.SelectedNode = this;
            return;
        }

        if (!_buildManager.CanBuild)
        {
            return;
        }

        BuildTower(_buildManager.TowerToBuild);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!_buildManager.CanBuild)
        {
            return;
        }

        if (_buildManager.HasMoneyToBuild && CurrentTower == null)
        {
            _renderer.material.color = HoverColor;
        }
        else
        {
            _renderer.material.color = NotEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        ResetColor();
    }
}
