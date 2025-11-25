using TMPro;
using UnityEngine;

public class ValueTextController : ValueUIController<string>
{
    [Header("Component")]
    [SerializeField] TextMeshProUGUI text;

    protected override void ValueChangedHandler(string value)
    {
        text.text = value;
    }
}