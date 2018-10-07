using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="Enums/Season")]
public class Season : EnumItem
{
    [Range(0, 1)]
    public float yearProgress;
    public Season nextSeason;
    public List<RessourceTransaction> seasonModifiers;
}
