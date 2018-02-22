using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;


class Dough
{
    private const double WHITE = 1.5;
    private const double WHOLEGRAIN = 1.0;
    private const double CRISPY = 0.9;
    private const double CHEWY = 1.1;
    private const double HOMEMADE = 1.0;


    private string flourType;
    private string bakingTechnique;
    private double weight;
    private double calories;

    private string FlourType
    {
        get => this.flourType;
        set {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        } 
           
    }

    private string BakingTechnique
    {
        get => this.bakingTechnique;
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    private double Weight
    {
        get => this.weight;
        set {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value; }
    }

    public double Calories
    {
        get => this.calories;
       
        
    }
    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;

        if (FlourType.ToLower() == "white")
        {
            calories = 2 * WHITE;
        }
        else if (FlourType.ToLower() == "wholegrain")
        {
            calories = 2 * WHOLEGRAIN;
        }
        if (BakingTechnique.ToLower() == "crispy")
        {
            calories *= CRISPY;
        }
        else if (BakingTechnique.ToLower() == "chewy")
        {
            calories *= CHEWY;
        }
        else if (BakingTechnique.ToLower() == "homemade")
        {
            calories *= HOMEMADE;
        }

        this.calories *= Weight;
    }


}

