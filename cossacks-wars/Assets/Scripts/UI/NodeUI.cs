using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;

    [Header("Upgrade")]
    public Text UpgradeCost;
    public Button UpgradeButton;

    [Header("Sell")]
    public Text SellCost;
    public Button SellButton;

    private Node _target;

    //
    // Custom Functions
    //
    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = _target.GetBuildPosition();

        var upgrades = _target.CurrentTowerBlueprint.Upgrades;
        if (_target.UpgradeIndex >= upgrades.Count)
        {
            UpgradeCost.text = "DONE";
            UpgradeButton.interactable = false;
        }
        else
        {
            UpgradeCost.text = MoneyHelper.AddHryvnyaSign(upgrades[_target.UpgradeIndex].Cost);
            UpgradeButton.interactable = true;
        }
        SellCost.text = MoneyHelper.AddHryvnyaSign(_target.CurrentTowerBlueprint.GetSellCost(_target.UpgradeIndex));

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTower();
        BuildManager.Instanse.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTower();
        BuildManager.Instanse.DeselectNode();
    }

    //
    // Unity Functions
    //
    private void Update()
    {
        if (!UI.activeSelf)
        {
            return;
        }

        var upgrades = _target.CurrentTowerBlueprint.Upgrades;
        if (_target.UpgradeIndex < upgrades.Count && PlayerStats.Instanse.GetMoney() >= upgrades[_target.UpgradeIndex].Cost)
        {
            UpgradeButton.interactable = true;
        }
        else
        {
            UpgradeButton.interactable = false;
        }
    }
}
