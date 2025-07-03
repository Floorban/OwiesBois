using UnityEngine;

public class HumanScript : MonoBehaviour{
    enum appearance { 
        Ugly,
        Mid,
        Pretty,
        Smexy
    }
    enum colour { 
        Green,
        Blue,
        Red
    }

    [SerializeField] float weight;
    [SerializeField] appearance looks;
    [SerializeField] colour race;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        weight = Random.Range(40, 151);
        switch (Random.Range(0,5)) { 
            case 0:
                looks = appearance.Ugly;
                break;
            case 1:
                looks = appearance.Mid;
                break;
            case 2:
                looks = appearance.Pretty;
                break;
            case 3:
                looks = appearance.Smexy;
            break;
        }
        switch (Random.Range(0, 4)) {
            case 0:
                race = HumanScript.colour.Green;
            break;
            case 1:
                race = HumanScript.colour.Blue;
            break;
            case 2:
                race = HumanScript.colour.Red;
            break;
        }
    }

    public int GetValue() {
        int raceValue = 0;
        int appearanceValue = 0;
        switch (race) {
            case colour.Green:
                raceValue = 10;
                break;
            case colour.Blue:
                raceValue = 20;
                break;
            case colour.Red:
                raceValue = 30;
            break;
        } switch (looks) {
            case appearance.Mid:
                appearanceValue = 10;
                break;
            case appearance.Pretty:
                appearanceValue = 20;
            break;
            case appearance.Smexy:
                appearanceValue = 30;
            break;
        }
        return (int)(weight * 0.5 + raceValue * 0.3 + appearanceValue * 0.2) * 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
