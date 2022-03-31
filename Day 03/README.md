# Day 03 - Layout Panels and Resources
### Projects:
|     |     |
| --- | --- |
| [FunWithDependencyProperties](FunWithDependencyProperties/) | WPF Dependency Properties | 
| [FunWithBinding](FunWithBinding/) | Data Binding, sources, and converters |

### Dependency Properties
* We have talked about the **Property Service** as a storage for property values for objects
* We talked about the `DependencyObject` class and the fact that it provides access to dependency properties.
* We saw how to define a new dependency property token using the `DependencyProperty.Register` static method.
* We saw how to define default value to the property
* We saw how to define a style that changes the property
* We saw how to query the source of the data using `DependencyPropertyHelper`.
* We saw how to **Coerce** the value of the dependency property
* We saw how to respond to value changes of the property using the `OnChange` callback.
* We saw how to use `Style Trigger` inside style in order to conditionaly set a property value according to the value of another property (for example `IsMouseOver`)
* We saw how to define property behaviors such as inheritance, default binding and more, using the `FrameworkPropertyMetadata`

### Attached Properties
* We understood that at the core - **All dependency properties may be attached to every dependency object**. 
* Still, mostly for XAML purposes, we can specifically define a property as **Attached Property** using the `RegisterAttached` method. This specifically indicates that the property isd designated to be attached to **other** objects.
* We saw how to implement **Attached Behavior** By responding to the property changes and implementing some logic as a result.
* We demonstrated how to create a template that binds to attached properties.
* We saw that actually, we almost never need to inherit from a control in order to extend it
  * We can create an alternate look using the template
  * We can add data properties using attached properties
  * We can add custom behaviors controlled by properties using **Attached Behaviors**


### Data Binding
* We understood that a binding is an external object that synchronizes the value of properties
* We saw that the object is defined by 4 things:
  * The source object - which can be any object
  * The source property path - which can be any property on the source object, or a path from it through other objects to a final source property.
  * The target object - which must be a `DependencyObject`
  * The target property - which must be a `DependencyProperty`
* We saw that we can also add
  * Mode: One way, Two way, One time, and more
  * Converter: A value converter to modify the data that is synchronized
  * And other binding properties which we did not talk about:
    * `UpdateSourceTrigger` - controls when to update the source property on two way bindings
    * `FallbackValue` - a value to use when the binding is not legal
    * `NullValue` - a value to use when the source is null
* We saw how to use Value converters, and how to write them
* We saw how to define the binding source
  * Data Context - by default
  * Element by name
  * Self
  * Templated Parent
* We saw that implementing `INotifyPropertyChanged` on the source means that the binding knows to refresh the target value whenever the source changes
* We saw how to create binding "Programatically" in C#
* Finally we saw a cool example of how to implement a sophisticated template for `ProgressBar` using `MultiBinding` cobined with `TemplatedParent` source


