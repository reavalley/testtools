# Test Tools

Test Tools is a set of tools intended to be used during unit testing.

#### Builder

A generic implementation of the Builder pattern to allow fluent BDD style creation of objects.

Example usage
```c#
var result = Builder.For<Pet>()
        .With(x => x.Name, "Beed")
        .With(x => x.Age, 5)
        .With(x => x.Breed, "Border Jack")
        .Build();
```

Use the BuilderComponent class to aid reuse.
```c#
public class PetBuilder 
{
    public static BuilderComponent<Pet> Default()
    {
        return new BuilderComponent<Pet>()
            .With(x => x.Name, "Beed")
            .With(x => x.Age, 5)
            .With(x => x.Breed, "Border Jack")
            .With(x => x.Toys, new List<string>()
            {
                "Ball",
                "Ring"
            });
    }
}
```

Example usage
```c#
var result = PetBuilder.Default().Build();
```
