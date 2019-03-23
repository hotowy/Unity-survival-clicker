using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActionController : MonoBehaviour {

    public Slider expBar;
    public TextMesh textLevel;
    public TextMesh textResources;


    private GameObject popUpEarnText;
    private GameObject lvlUpParticles;
    private Animator animator;

    private long resources;
    private long level;
    private long exp;
    private float reqExp;

    

    

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        popUpEarnText = Resources.Load<GameObject>("Prefabs/actionEarnText");
        lvlUpParticles = Resources.Load<GameObject>("Prefabs/lvlUpParticles");
        level = 1;
        exp = 0;
    }
	
	// Update is called once per frame
	void Update () {
        ProceedExperience();
        ProceedResources();
        
        

    }

    void OnMouseDown()
    {
        exp += 1;
        resources += 1;
        animator.Play("actionClickAnimation");
        ShowPopUpEarnText();

    }

    private void ProceedResources()
    {
        textResources.text = resources.ToString();
    }

    private void ProceedExperience()
    {
        textLevel.text = level.ToString();
        reqExp = level * level * 2 + 20;
        expBar.value = CalculateExpProgress();
        if(exp >= reqExp)
        {
            ProceesLvlUp();
            
        }
    }

    private void ProceesLvlUp()
    {
        level++;
        exp = 0;
        var targetEffectLocation = textLevel.transform.position;
        targetEffectLocation.z = -2;
        Instantiate(lvlUpParticles, targetEffectLocation, Quaternion.identity);
    }

    

    private void ShowPopUpEarnText()
    {
        GameObject text = Instantiate(popUpEarnText, transform);
        Animator textAnimator = text.GetComponent<Animator>();
        textAnimator.Play("earnTextFlowAnimation");
        Destroy(text, textAnimator.GetCurrentAnimatorStateInfo(0).length);

    }

    private float CalculateExpProgress()
    {
        return exp / reqExp;
    }
}
