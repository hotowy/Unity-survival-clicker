using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product {

    private string name;
    private long cost;
    private long amount;
    private long resourcesPerSecond;

    public Product(string name, long cost, long resourcesPerSecond)
    {
        this.name = name;
        this.cost = cost;
        amount = 0;
        this.resourcesPerSecond = resourcesPerSecond;
    }

}
