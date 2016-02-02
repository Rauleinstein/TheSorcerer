using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class RandomSpell : MonoBehaviour
{
    public Text spellUI;
    public GameObject spellScroll;
    // Use this for initialization
    void Start()
    {
        
        System.Random rnd = new System.Random();
        int[] numbers = Enumerable.Range(0, 5).OrderBy(r => rnd.Next()).ToArray();

        foreach (int i in numbers)
        {
            print(i);
        }

        string spell;


        //The actions that the player has to do to be able to cast the spell
        //The actions has to be done in a random secuence 
        string[] actions = {
            "the rock dives into the water",
            "the wood stick facing the river",
            "the water goes into the spellcaster",
            "the spellcaster draws in the sand",
            "the magic stone goes in the hand"
        };

        spell = string.Format("For creating sucessful bridge \n in the first place {0} \n then {1} \n and followed by {2} \n in the next step {3} \n before casting the spell {4}", actions[numbers[0]], actions[numbers[1]], actions[numbers[2]], actions[numbers[3]], actions[numbers[4]]);
        print(spell);
        spellUI.text = spell;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            print(spellScroll.activeSelf.ToString());
            spellScroll.SetActive(!spellScroll.activeSelf);
        }
        if (Input.GetMouseButtonDown(0))
        {
            spellScroll.SetActive(false);
        }
    }
}
