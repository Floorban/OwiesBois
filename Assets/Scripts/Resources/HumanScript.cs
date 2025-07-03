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

    [SerializeField] float weigh;
    [SerializeField] appearance looks;
    [SerializeField] colour race;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        weigh = Random.Range(40, 151);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
