using UnityEngine;

public class LevelNumberSetter : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    public void SetText(int number)
    {
        _text.text = "LEVEL " + number.ToString();
    }
}
