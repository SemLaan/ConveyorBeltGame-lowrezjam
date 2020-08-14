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

                switch (tileGrid.tilegrid[x, y])
                {

                    case TileType.empty:
                        Handles.DrawSolidRectangleWithOutline(verts, Color.grey, Color.black);
                        break;
                    case TileType.wall:
                        Handles.DrawSolidRectangleWithOutline(verts, Color.yellow, Color.black);
                        break;
                    case TileType.conveyorUp:
                    case TileType.conveyorDown:
                    case TileType.conveyorLeft:
                    case TileType.conveyorRight:
                        Handles.DrawSolidRectangleWithOutline(verts, Color.green, Color.black);
                        DrawConveyorArrow(tileGrid.tilegrid[x, y], new Vector2(x + 1, y + 1));
                        break;
                    case TileType.finishTile:
                        Handles.DrawSolidRectangleWithOutline(verts, Color.red, Color.black);
                        break;

                }
            }

        needsRepaint = false;
    }

    private void DrawConveyorArrow(TileType conveyorType, Vector2 tilePosition)
    {

        Vector3 direction = Vector3.zero;

        switch (conveyorType)
        {

            case TileType.conveyorUp:
                direction = Vector3.left * 90;
                break;
            case TileType.conveyorDown:
                direction = Vector3.right * 90;
                break;
            case TileType.conveyorLeft:
                direction = Vector3.down * 90;
                break;
            case TileType.conveyorRight:
                direction = Vector3.up * 90;
                break;
        }

        Handles.ArrowHandleCap(0, (Vector3) tilePosition + Vector3.back, Quaternion.Euler(direction), 0.45f, EventType.Repaint);
    }
}
