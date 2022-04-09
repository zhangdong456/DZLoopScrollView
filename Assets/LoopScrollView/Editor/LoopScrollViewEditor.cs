using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScrollView
{
    [CustomEditor(typeof(LoopScrollView))]
    public class LoopScrollViewEditor : Editor
    {
        private LoopScrollView listView;
        public override void OnInspectorGUI()
        {
          
            listView=target as LoopScrollView;
            listView.m_Direction = (e_Direction)EditorGUILayout.EnumPopup("循环轴向:", listView.m_Direction);
            if (listView.m_Direction== e_Direction.Horizontal)
            {
                listView.m_Row = EditorGUILayout.IntField("行数:", listView.m_Row);
            }
            else
            {
                listView.m_Row = EditorGUILayout.IntField("列数:", listView.m_Row);
            }
            EditorGUILayout.Space(10f);
            listView.m_topPadding = EditorGUILayout.FloatField("顶部距离:", listView.m_topPadding);
            listView.m_bottonPadding = EditorGUILayout.FloatField("底部距离:", listView.m_bottonPadding);
            listView.m_Spacing = EditorGUILayout.FloatField("间距:", listView.m_Spacing);
            EditorGUILayout.Space(10);
            listView.m_CellGameObject=EditorGUILayout.ObjectField("预制子物体：",listView.m_CellGameObject,typeof(GameObject),true) as GameObject;
        }
    }
}


