using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TileGrid))]
public class LevelEditor : Editor
{

    TileGrid tileGrid;


    private void OnEnable()
    {

        tileGrid = target as TileGrid;
    }


    private void OnSceneGUI()
    {

        Event guiEvent = Event.current;

        Ray mouseRay = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition);
        float drawPlaneHeight = 0;
        float dstToDrawPlane = (drawPlaneHeight - mouseRay.origin.z) / mouseRay.direction.z;
        Vector3 mousePosition = mouseRay.GetPoint(dstToDrawPlane);

        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0)
        {

            int x = Mathf.RoundToInt(mousePosition.x);
            int y = Mathf.RoundToInt(mousePosition.y);

            Debug.Log(x + " : " + y);

            Undo.RecordObject(tileGrid, "Change tile");
            tileGrid.tilegrid[x, y] = tileGrid.tileBrush;

            Debug.Log(tileGrid.tilegrid[0, 0]);
        }

        if (guiEvent.type == EventType.Layout)
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
    }
}
