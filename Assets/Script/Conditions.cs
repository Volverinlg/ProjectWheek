using TMPro;
using UnityEngine;

public class Conditions : MonoBehaviour{
    private TextMeshProUGUI _loseText;
    private TextMeshProUGUI _winText;

    public void Start(){
        _winText = GetComponent<TextMeshProUGUI>();
        _winText.enabled = false;
         Vererbung.Win.AddListener(Win);
         
         _loseText = GetComponent<TextMeshProUGUI>();
         _loseText.enabled = false;
         Ship.Lose.AddListener(Lose);
    }

    private void Lose(){
        _loseText.enabled = true;
    }

    private void Win(){
        _winText.enabled = true;
    }
}
