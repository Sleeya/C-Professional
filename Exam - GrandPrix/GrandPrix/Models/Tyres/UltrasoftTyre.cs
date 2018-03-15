using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        base.Name = "Ultrasoft";
        this.Grip = grip;
    }

    private double Grip
    {
        get => this.grip;
        set => this.grip = value;
    }

    public override void DegradadeTyre()
    {
        if ((this.Degradation - (this.Hardness + this.Grip)) < 30)
        {
            throw new ArgumentException();
        }
        this.Degradation -= (this.Hardness + this.Grip);
    }

    public override void ChangeGrip(double grip)
    {
        this.Grip = grip;
    }
}
