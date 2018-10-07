using UnityEngine;

[CreateAssetMenu(menuName ="Enums/RessourceType")]
public class RessourceType : EnumItem
{
    public Sprite icon;
    public GameEvent ressourceChangedEvent;
    public FloatVariable valueReference;
    public FloatVariable maxValueReference;
}
