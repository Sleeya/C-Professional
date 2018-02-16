using System;
using System.Collections.Generic;
using System.Text;


class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Children> children;
    private List<Parents> parents;
    private List<Pokemon> pokemons;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public List<Children> Children
    {
        get { return this.children; }
    }

    public List<Parents> Parents
    {
        get { return this.parents; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
    }
    public Person()
    {
        this.children = new List<Children>();
        this.parents = new List<Parents>();
        this.pokemons = new List<Pokemon>();
    }

    public void AddChildren(Children child)
    {
        children.Add(child);
    }

    public void AddParents(Parents parent)
    {
        parents.Add(parent);
    }

    public void AddPokemons(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
    }


}

