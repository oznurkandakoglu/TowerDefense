using UnityEngine;
using UnityEngine.EventSystems;

public class Nodes : MonoBehaviour
{
    public Color notEnoughMoneyColor;
    public Color hoverColor;
    public Vector3 positionOffSet;
    public Quaternion rotation;

    [Header("Optional")]
    public GameObject turret;
    
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffSet;
    }

    void OnMouseEnter() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }
            
    }

    void OnMouseDown() {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Shoptan item secili degilken taret kurmayi engeller.
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Cant build there!");
            return;
        }

        //Building a turret
        buildManager.BuildTurretOn(this);  
    }
    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
