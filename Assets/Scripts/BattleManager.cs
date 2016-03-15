using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    private List<Unit> activeUnits;

    // Use this for initialization
    void Start()
    {
        activeUnits = new List<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Unit unit1 = activeUnits.FirstOrDefault(x => x.unitName == "Katapeltes");
            Unit unit2 = activeUnits.FirstOrDefault(x => x.unitName == "Turma");

            unit2.Damage(unit1.damage, unit1.damageType);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Unit unit1 = activeUnits.FirstOrDefault(x => x.unitName == "Katapeltes");
            Unit unit2 = activeUnits.FirstOrDefault(x => x.unitName == "Cheiroballista");

            unit2.Damage(unit1.damage, unit1.damageType);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Unit unit1 = activeUnits.FirstOrDefault(x => x.unitName == "Turma");
            Unit unit2 = activeUnits.FirstOrDefault(x => x.unitName == "Katapeltes");

            unit2.Damage(unit1.damage, unit1.damageType);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Unit unit1 = activeUnits.FirstOrDefault(x => x.unitName == "Turma");
            Unit unit2 = activeUnits.FirstOrDefault(x => x.unitName == "Cheiroballista");

            unit2.Damage(unit1.damage, unit1.damageType);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Unit unit1 = activeUnits.FirstOrDefault(x => x.unitName == "Cheiroballista");
            Unit unit2 = activeUnits.FirstOrDefault(x => x.unitName == "Katapeltes");

            unit2.Damage(unit1.damage, unit1.damageType);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Unit unit1 = activeUnits.FirstOrDefault(x => x.unitName == "Cheiroballista");
            Unit unit2 = activeUnits.FirstOrDefault(x => x.unitName == "Turma");

            unit2.Damage(unit1.damage, unit1.damageType);
        }
    }

    public void RegisterUnit(Unit unit)
    {
        activeUnits.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        activeUnits.Remove(unit);
    }
}
