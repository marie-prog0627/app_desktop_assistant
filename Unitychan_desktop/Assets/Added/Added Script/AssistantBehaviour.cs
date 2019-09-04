using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantBehaviour: MonoBehaviour {

    private Animator animator;
    private int ActionNum = 0;

    // Inspector
    [SerializeField] private WSVoiceRecognition Recognition;

    int hashPhase = Animator.StringToHash("Phase");

    void Start(){
        animator = GetComponent<Animator>();
        Recognition = GetComponent<WSVoiceRecognition>();
    }
    
    void Update(){
        var state = animator.GetCurrentAnimatorStateInfo(0);

        animator.SetInteger("State", Action(Recognition.Key));
        Debug.Log("Assist Judge");
        Debug.Log(Recognition.Key);

        Debug.Log(state.IsName("Base Layer.wait." + Recognition.Key));

        if(state.IsName("Base Layer.wait." + Recognition.Key)){
            Recognition.Key = "";
        }

    }

    int Action(string key){
        int num = 0;
        switch(key){
            case "こんにちは":
                num = 2;
                break;
            case "さようなら":
                num = 3;
                break;
            case "開いて":
                num = 4;
                break;
            default:
                break;
        }
        return num;
    }

    /* override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("Assist Judge");
        Debug.Log(Recognition.KeyNum);

        animator.SetInteger(hashRandom,  Recognition.KeyNum);

        Recognition.KeyNum = Random.Range(0,1);
    } */
}
