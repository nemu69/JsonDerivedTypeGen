# JsonDerivedGenerator
Source Code Generator for System.Text.Json, add JsonDerivedType attributes on polymorphic classes

## Requirement
Classe need the `partial` and `JsonPolymorphic` attribute


## Example

Source file
```
[JsonPolymorphic]
public partial class DTOBaseClass
{
    public string Property1 { get; set; }
}
```

Generated File

```
[JsonDerivedType(typeof(JsonDerivedGenerator.Playground.DTOInheritedClass1), "InheritedClass1")]
[JsonDerivedType(typeof(JsonDerivedGenerator.Playground.DTOInheritedClass2), "InheritedClass2")]
public partial class DTOBaseClass
{
}
```
