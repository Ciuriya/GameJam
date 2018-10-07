using UnityEngine;
using UnityEngine.UI;

public class Indicateur : MonoBehaviour
{
    public Text indicateur;
    public FloatVariable valueRef;
    public FloatVariable maxValueRef;

    public void OnEnable()
    {
        UpdateIndicateur();
    }

    public void UpdateIndicateur()
    {
        indicateur.text = valueRef.Value + "/" + maxValueRef.Value;
    }
}
