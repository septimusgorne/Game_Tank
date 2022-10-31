using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
//script for change Inventory
public class InventoryEditor : Editor 
{ 
   private Inventory _inventory;
    //create variable inventory
    public void OneEnable()
    {
        _inventory = (Inventory)target;
        //targer it is inventory for art
    }
    public override void OnInspectorGUI()
    {
        if(_inventory.Items.Count > 0)
        {
            foreach  (Inventory.Item item in _inventory.Items)
            {
                EditorGUILayout.BeginVertical("box");
                item.id = EditorGUILayout.IntField("�������������", item.id);
                item.name = EditorGUILayout.TextField("��� ��������", item.name);
                item.Image = (Sprite)EditorGUILayout.ObjectField("������", item.Image, typeof(Sprite), false);
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("��������� ������, ���������� ���");
        }
        if (GUILayout.Button("�������� �������",GUILayout.Width(200), GUILayout.Height(30)))
            _inventory.Items.Add(new Inventory.Item());
    }
}
