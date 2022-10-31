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
                item.id = EditorGUILayout.IntField("Идентификатор", item.id);
                item.name = EditorGUILayout.TextField("Имя предмета", item.name);
                item.Image = (Sprite)EditorGUILayout.ObjectField("Спрайт", item.Image, typeof(Sprite), false);
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("Инвентарь пустой, предеметов нет");
        }
        if (GUILayout.Button("Добавить предмет",GUILayout.Width(200), GUILayout.Height(30)))
            _inventory.Items.Add(new Inventory.Item());
    }
}
