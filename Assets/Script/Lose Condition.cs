using TMPro;
using UnityEngine;

public class LoseCondition : MonoBehaviour{
    private TextMeshProUGUI _loseText;

    public void Start(){
         _loseText = GetComponent<TextMeshProUGUI>();
         _loseText.enabled = false;
         Ship.Lose.AddListener(Lose);
    }

    private void Lose(){
        _loseText.enabled = true;
    }
    
}
