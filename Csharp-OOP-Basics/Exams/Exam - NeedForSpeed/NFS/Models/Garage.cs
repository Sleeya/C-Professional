using System.Collections.Generic;

public class Garage
{
    private List<Car> parkedCars;

    public Garage()
    {
        this.ParkedCars=new List<Car>();
    }

    public List<Car> ParkedCars
    {
        get => this.parkedCars;
        private set => this.parkedCars = value;
    }

    public  void ParkCar(Car car)
    {
        this.ParkedCars.Add(car);
    }

    public void UnparkCar(Car car)
    {
        this.ParkedCars.Remove(car);
    }
}
