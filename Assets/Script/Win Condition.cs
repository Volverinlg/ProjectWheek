using TMPro;
using UnityEngine;

public class WinCondition : MonoBehaviour{
    private TextMeshProUGUI _winText;

    public void Start(){
        _winText = GetComponent<TextMeshProUGUI>();
        _winText.enabled = false;
        Enemy_DMG_Handling.Win.AddListener(Win);
    }
    private void Win(){
        _winText.enabled = true;
    }
}
