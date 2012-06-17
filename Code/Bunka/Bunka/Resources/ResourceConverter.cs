﻿using Microsoft.Xna.Framework;

// class for converting one resource into another
class ResourceConverter
{
    ResourceManager resourceManager;
    Resource[] input, output;
    ResourceType[] inputTypes, outputTypes;
    float speed, timer;
    byte[] inSize, outSize;

    public ResourceConverter(ResourceManager resourceManager, ResourceType[] inputTypes, ResourceType[] outputTypes, byte[] inSize, byte[] outSize, float speed)
    {
        this.resourceManager = resourceManager;
        this.inputTypes = inputTypes;
        this.outputTypes = outputTypes;
        this.inSize = inSize;
        this.outSize = outSize;
        this.speed = this.timer = speed;
        this.input = new Resource[inputTypes.Length];
        this.output = new Resource[outputTypes.Length];
    }

    public void Update(GameTime t)
    {
        if (timer > 0)
            timer -= (float)t.ElapsedGameTime.TotalSeconds;

        if (timer <= 0 && CanConvert)
        {
            for (int i = 0; i < input.Length; i++)
                input[i].Amount -= inSize[i];
            for (int i = 0; i < output.Length; i++)
                output[i].Amount += outSize[i];
            timer = speed;
        }
    }

    //////////////////
    //  PROPERTIES  //
    //////////////////

    public Resource[] Input
    {
        get { return input; }
    }

    public Resource[] Output
    {
        get { return output; }
    }

    public ResourceType[] InputTypes
    {
        get { return inputTypes; }
    }

    public ResourceType[] OutputTypes
    {
        get { return outputTypes; }
    }

    public byte[] InputSize
    {
        get { return inSize; }
    }

    public byte[] OutputSize
    {
        get { return outSize; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    bool CanConvert
    {
        get
        {
            for (int i = 0; i < input.Length; i++)
                if (input[i] == null || input[i].Amount < inSize[i])
                    return false;
            return true;
        }
    }
}