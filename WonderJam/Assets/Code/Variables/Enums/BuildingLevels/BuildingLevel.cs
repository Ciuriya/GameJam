using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Enums/BuildingLevel")]
public class BuildingLevel : EnumItem
{
    //public FloatReference maxValue;
    public RessourceTransaction ressourceGenTransaction;
    public List<RessourceTransaction> upgradeCosts;
    public float maxStorageIncrement;
    public BuildingLevel nextLevel;    
}
