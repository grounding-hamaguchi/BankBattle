﻿using UnityEngine;
using System.Collections;

public class CreateFloor : MonoBehaviour {

    //ステージの床として生成するブロック。
    public GameObject block;

    //読み込むテキストファイルを入れておくもの。
    public TextAsset textAsset;

    Vector3 createPos;

    public Vector3 spaceScale;

    // Use this for initialization
    void Start () {
        createPos = Vector3.zero;
        CreateStage(createPos);
	}

    void CreateStage(Vector3 pos)
    {
        Vector3 originPos = pos;
        //テキストファイルが読み込まれている。
        string stageTextData = textAsset.text;
        //改行が入るとSplit関数で文章分けることが出来る。
        string[] stArrayData = stageTextData.Split('\n');
        //この番号がテキストファイルに書かれていればblockを生成する。
        int result = 1;

        GameObject obj = null;

        foreach (string c in stArrayData)
        {
            //cでもってきた一行のデータを「,」で区切ってひとつずつ読むようにする。
            string[] oneLine = c.Split(',');
            for(int i = 0; i < oneLine.Length; ++i)
            {
                //oneLine[i]にはいっているものがCreateblockNumと同じだったらtrueそれ以外が入っていたらfalse
                bool isInt = int.TryParse(oneLine[i], out result);
                if(isInt && result == 1)
                {
                    //正常に読み込まれたらブロックを生成。
                    obj = Instantiate(block, pos, Quaternion.identity) as GameObject;
                }
                //生成してもしなくてもx軸をずらして次に進む。
                pos.x += obj.transform.lossyScale.x;
            }
            //z軸をずらす。
            pos.z += spaceScale.z;
            //z軸を最初の値に戻す。
            pos.x = originPos.x;

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
