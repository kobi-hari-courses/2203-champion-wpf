# Day 02 - Layout Panels and Resources
### Projects:
|     |     |
| --- | --- |
| [FunWithLayout](FunWithLayout/) | Understanding WPF Layout and Panels | 
| [Ex1Solution](Ex1Solution/) | Solution to exercise 1 on Templates |
| [FunWithResourcesAndStyles](FunWithResourcesAndStyles/) | Styles, Triggers, Animations and other resources |

### Layout and Layout Properties
* Layout in WPF is a 2-pass algorithm.
  * The **measure** pass where each parent asks child to measure the minimum space required for its presentation
  * The **arrange** pass where eah parent allocates space and position for its child
* The layout passes allocate the **Bounding Box** for its children.
* Once a bounding box is allocated, the layout properties arrange the element inside the box
  * The `Margin` property may allocate some of the bounding box for whitespace and reduce the effective available box
  * The `Width` and `Height` properties may give the element a size that is different than the bounding box. 
  * If the `Width` and `Height` are not set, then the `MinWidth`, `MinHeight`, `MaxWidth` and `MaxHeight` properties may still limit the size
  * The `VerticalAlignment` and `HorizontalAlignment` may set the sizing and position of the element.
    * If the value `Stretch` is used, then the element will be sized according to the available box. (assuming `Width` and `Height` are not set)
    * Otherwise, the element will be sized according to the measure pass.
    * The alignment will set the position of the element within the bounding box
* Custom layout behavior may be programmed into new element classes by overriding the layout methods:
  * `MeasureOverride`
  * `ArrangeOverrride`

  
### The various Panels of WPF
* The `Canvas` panel is the most simple panel because it does not really do any calculations. It simply places each element when it asks to be.
  * Alignment is never relevant because the box allocated for each element is exactly what it requires to be.
  * Position is controlled using the `Canvas.Top` `Canvas.Left`, `Canvas.Bottom` and `Canvas.Right` properties.
* The `StackPanel` is a useful panel for stacking elements in one direction
  * It can either be horizontal or vertical
  * In the stacking direction, the element will always get exactly the desired size
  * In the other dimension, the panel calcualtes the max desired size of all the children, and then allocates that maximum to all of them
*  The `WrapPanel` is a useful panel for stacking and wrapping of elements. It stacks elements in a single direction and then wraps to the next stack if there is not enough space in the container
*  The `DockPanel` is useful for docking elements to the panel boundaries and to fill the ramainder space
   *  `LastChildFill` property decides if the last child fills the entire space that remains after previous children are placed
   *  Each child has a docking direction controlled by the `DockPanel.Dock` property
   *  Multiple elements may be stacked to the same direction
*  The `Grid` panel is the most versitile panel of them all
   *  It is used to fill spaces in 2 dimensions
   *  First you use the `ColumnDefinitions` and `RowDefinitions` properties to divide the space into rows and columns
   *  Then you can place elements in cells using the `Grid.Row` and `Grid.Column` properties
   *  You can span an element on a rectangle of cells using `Grid.RowSpan` and `Grid.ColumnSpan`
   *  Columns and Rows may have various size logics:
      *  `auto` sizing - the row or column will have the minimum size required to fit its content
      *  `pixel` sizing - provides the exact size for the row or column
      *  `star` sizing - divides the remaining space according to proportional weights
   *  We have seen how to use `GridSplitter` along with `Grid` in order to allow to user to resize rows and columns
   *  We have talked about `Size Sharing Group` to allow different grids to share sizing definitions


### Resources and Styles
* We have talked about `ResourceDictionary` and the fact that each element in the visual tree has this property
* We said that `{StaticResource}` and `{DynamicResource}` search for resources by traveling up the **logical tree**
* We saw that each resource in the resource dictionary must have an `x:Key` except for `DataTemplate` and `Style`
  * If the key is ommited, they become default for their target type within the scope of the resource dictionary
* We talked about the fact that "visual" elements can not be resources since they cannot be reused. Each visual element can be placed in the visual tree only at one place.
* We said that resources should usually be either **immutable** (meaning that the classes are readonly and the properties cannot change) or **frozen** (meaning the the classes implement `IFreezble` when you can set the object as **frozen** which turns the properties into read-only).
* In any case - you should not change properties of resource once they are already used as resources.
* We saw some example of objects that are good candidates to be used as resources
  * Brushes
  * Colors
  * Geometries
  * Animations
  * Templates
  * Styles
  * Storyboards
* We saw that a `Style` is an object that defines values for properties. 
  * We saw that a `Style` object contains a list of `Setter` objects, each one defines a specific value to a specific property
  * We saw that each `Style` has `TargetType` which determines which properties are relevant for this style. A style object can be provided to an element only if the element's type is the styles `TargetType`
  * We saw that if we set a property directly on an element, it overrides the value that it receives from the style
  * We saw that a style can set any property of the element (excpet for the `Style` property itself)
  * We saw that a `Style` object can be "Based On" a different style, which means that it inherits all the property setters of the base style
* We talked about animations
  * We said that an `Animation` is like a single style setter, in the sense that it provides a value to a specific property.
  * We said that a `Storyboard` is like a single `Style` since it contains several animations where each sets a single property with a value.
  * There are 3 main differences between styles and storyboards
    1. A style setter is "weaker" than a local value, so if you provide a property with local value it overides the setter value. Animation value, on the other hand, is **stronger** than local value. 
    2. A style setter sets the property value **instantly** while an animation setter sets it over time
    3. You can only provide a single style object to an element. But you can apply many storyboards
* We talked about `Triggers`
  * We saw that each UI element has a `Triggers` property which is a list of `Trigger` objects
  * A trigger object contains 2 parts: The trigger cause, and the trigger action
    * The trigger cause is an object that describes what the triggers responds to, when it is triggered
    * The trigger action is an object that describes the side effect of the trigger
  * We saw that in the `Triggers` property we may only use a specific type of trigger called `EventTrigger` which is triggered by a specific event
  * We saw that we may use the `StartStoryboard` action so that the trigger causes a storyboard to play
  * We saw an example of how to respond to a `Loaded` event of an element in order to play a storyboard on it
* We saw how to set the storyboard "repeat" behavior to make it loop forever.
* We saw how to create an animation with several keyframes
* We saw how to set easing functions to each keyframe




  