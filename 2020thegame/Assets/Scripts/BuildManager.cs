using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError ("More than one BuildManager in scene.");
            return;
        }
        instance = this;
    }

    
    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; }}

    //Kuleyi kurmak için çağırılan fonksiyon.
    public void BuildTurretOn (Nodes node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Money left:" + PlayerStats.Money);
    }

    //Çağırıldığında seçilmesi istenilen kuleyi döndürür.
    public void SelectTurretToBuild (TurretBlueprint turret) 
    {
        turretToBuild = turret;
    }
}
