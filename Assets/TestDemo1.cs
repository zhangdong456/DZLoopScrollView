using System.Collections;
using System.Collections.Generic;
using ScrollView;
using UnityEngine;
using UnityEngine.UI;

public class TestData
{
    public string index;
    public string content;
}

public class TestDemo1 : MonoBehaviour
{
    public LoopScrollView loopScrollView;
    // Start is called before the first frame update
    public int totalCount = 10000;
    private List<TestData> DataList=new List<TestData>();
    
    public ScrollRect scrollRect;
    void Start()
    {
        for (int i=0;i<totalCount;++i)
        {
            DataList.Add(new TestData
            {
                index = "编号" + i,
                content =UnityEngine.Random.Range(0,1000).ToString()
            });
        }

        loopScrollView.m_SpeicalCellAction = ProcessCallBack;
        loopScrollView.Init(CallBack);
        loopScrollView.ShowList(totalCount);

    }
    //针对某些需要判定scrollrect速率停止的时候处理一些 比如异步加载item图片等等
    private void ProcessCallBack(GameObject cell,int index)
    {
        int dataindex = index - 1;
       // Debug.LogWarning("特殊处理"+dataindex);
    }

    private void CallBack(GameObject cell,int index)
    {
        int dataindex = index - 1;
        cell.transform.Find("DelBtn").GetComponent<Button>().onClick.RemoveAllListeners();
        cell.transform.Find("DelBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            DataList.RemoveAt(dataindex);
            loopScrollView.DeleteItem(dataindex);
        });
        cell.transform.Find("UpdateBtn").GetComponent<Button>().onClick.RemoveAllListeners();
        cell.transform.Find("UpdateBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            DataList[dataindex].content = UnityEngine.Random.Range(0, 1000).ToString();
            loopScrollView.UpdateCell(dataindex);
        });
        cell.transform.Find("indexTxt").GetComponent<Text>().text =  DataList[dataindex].index;
        cell.transform.Find("Content").GetComponent<Text>().text =  DataList[dataindex].content;
    }
    
}
