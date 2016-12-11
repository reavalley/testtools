# Test Tools

Test Tools provides classes to make testing easier.

Inherit from Builder<,> to allow easy creation of test objects with a fluent interface to create objects in a BDD manner.

Create Builder class
```c#
private class PetBuilder : Builder<Pet, PetBuilder>
{
    
}
```

Use fluent interface to create object.
```c#
var result = PetBuilder.Init()
      .With(x => x.Name, "Beed")
      .With(x => x.Age, 5)
      .With(x => x.Breed, "Border Jack")
      .Build();
```
