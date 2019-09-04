using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class AssistantBehaviour: MonoBehaviour {

    private Animator animator;
    private int ActionNum = 0;

    // メンバ変数
    Process proc;

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
        UnityEngine.Debug.Log("Assist Judge");
        UnityEngine.Debug.Log(Recognition.Key);

        UnityEngine.Debug.Log(state.IsName("Base Layer.wait." + Recognition.Key));

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
            case "PowerPoint 開いて":
                num = 4;
                OpenApp("PowerPoint");
                break;
            default:
                break;
        }
        return num;
    }

    void OpenApp(string AppName){
        // 別アプリ(プロセス)起動
        proc = new Process();
        proc.StartInfo.FileName = "/Applications/Microsoft PowerPoint.app.installBackup";   // 起動させる別アプリ名をここに入れて下さい(フルパス指定でも可) 
        proc.Start();
    }

    // アプリ終了時に呼ばれる
    private void OnApplicationQuit()
    {
        // 別アプリ終了処理

        if (!proc.HasExited)
        {
            // 別アプリが起動中の場合のみ終了させる
            proc.CloseMainWindow();
        }

        proc.Close();
        proc = null;
    }

    /* override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        Debug.Log("Assist Judge");
        Debug.Log(Recognition.KeyNum);

        animator.SetInteger(hashRandom,  Recognition.KeyNum);

        Recognition.KeyNum = Random.Range(0,1);
    } */
}
