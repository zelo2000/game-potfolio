using Assets.Scripts.Models;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public NodeUI NodeUI;

    public static BuildManager Instanse { get; private set; }
    public bool CanBuild { get => _towerToBuild != null; }
    public bool HasMoneyToBuild { get => PlayerStats.Instanse.GetMoney() >= _towerToBuild.Build.Cost; }

    private TowerBlueprint _towerToBuild;
    public TowerBlueprint TowerToBuild
    {
        get => _towerToBuild;
        set
        {
            _towerToBuild = value;
            DeselectNode();
        }
    }

    private Node _selectedNode;
    public Node SelectedNode
    {
        get => _selectedNode;
        set
        {
            if (_selectedNode == value)
            {
                DeselectNode();
            }
            else
            {
                _selectedNode = value;
                _towerToBuild = null;

                NodeUI.SetTarget(value);
            }
        }
    }

    public void DeselectNode()
    {
        _selectedNode = null;
        NodeUI.Hide();
    }

    private void Awake()
    {
        if (Instanse != null)
        {
            Debug.LogError("More than one Build Manager at the scene!");
            return;
        }

        Instanse = this;
    }
}
