using System;

public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name
    {
        get => this.name;
        protected set => this.name = value;
    }

    public double Hardness
    {
        get => this.hardness;
        protected set => this.hardness = value;
    }

    public double Degradation
    {
        get => this.degradation;
        protected set
        {
            this.degradation = value;
        }
    }

    public virtual void DegradadeTyre()
    {
        if (this.Degradation - this.Hardness < 0)
        {
            throw new ArgumentException();
        }
        this.Degradation -= this.Hardness;
    }

    public virtual void ChangeGrip(double grip)
    {

    }

    public virtual void ChangeHardness(double hardness)
    {

    }
}
