using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
   [SerializeField] private Transform _cellIndicator;
   [SerializeField] private BuildInput _buildInput;
   [SerializeField] private Grid _grid;

   private void Update()
   {
      Vector3 mousePosition = _buildInput.GetSelectedPosition();
      Vector3Int gridPosition = _grid.WorldToCell(mousePosition);
      _cellIndicator.position = _grid.CellToWorld(gridPosition);
   }
}
