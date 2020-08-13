using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TileGrid))]
public class LevelEditor : Editor
{

    TileGrid tileGrid;
    private bool mouseDown = false;
    private bool needsRepaint = false;

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


        if (guiEvent.type == EventType.Repaint)
            DrawLevel();


        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0)
            mouseDown = true;
        else if (guiEvent.type == EventType.MouseUp && guiEvent.button == 0)
            mouseDown = false;

        if (mouseDown)
        {

            int x = Mathf.RoundToInt(mousePosition.x) - 1;
            int y = Mathf.RoundToInt(mousePosition.y) - 1;

            if (x >= 0 && x < tileGrid.levelSize.x && y >= 0 && y < tileGrid.levelSize.y)
                if (tileGrid.tilegrid[x, y] != tileGrid.tileBrush)
                {

                    Undo.RecordObject(tileGrid, "Change tile");
                    tileGrid.tilegrid[x, y] = tileGrid.tileBrush;
                    needsRepaint = true;
                }
        }

        if (needsRepaint)
            HandleUtility.Repaint();

        if (guiEvent.type == EventType.Layout)
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
    }


    private void DrawLevel()
    {

        for (int x = 0; x < tileGrid.levelSize.x; x++)
            for (int y = 0; y < tileGrid.levelSize.y; y++)
            {

                Vector3[] verts = new Vector3[]
                {
                    new Vector3(x + 0.5f, y + 1.5f),
                    new Vector3(x + 0.5f, y + 0.5f),
                    new Vector3(x + 1.5f, y + 0.5f),
                    new Vector3(x + 1.5f, y + 1.5f),
                };

                if (tileGrid.tilegrid[x, y] == TileType.empty)
                    Handles.DrawSolidRectangleWithOutline(verts, Color.grey, Color.grey);
            }

        needsRepaint = false;
    }
}
