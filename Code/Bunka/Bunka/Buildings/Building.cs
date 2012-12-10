﻿// parent class for all buildings
public abstract class Building
{
    BuildingType type;

    public Building(BuildingType type)
    {
        this.type = type;
    }

    //////////////////
    //  PROPERTIES  //
    //////////////////

    public BuildingType BuildingType
    {
        get { return type; }
    }
}