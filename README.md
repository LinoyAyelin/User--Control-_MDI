In this project, I implemented a UserControl that contains a random number of Label controls with random size and shape. The background of the controls is a random shade of one of the colors blue, red, or gray. I created the controls dynamically.
I created a window called Child with the following properties:

* Three RadioButtons with the text "Red", "Blue" and "Gray"
* A ComboBox with the text "Sort" with two values "Up" and "Down"
* A ComboBox with the text "Filter" with two values "Rectangle" and "Square"

I created a window called Container of type MDI that contains two Child type children that I created.
Clicking on a specific Child causes a random background color change of the other Child.

Goal:
* Filter the controls from the clicked UserControl by Rectangle/Square and by Red/Blue/Gray
* In addition, sort all controls by size, the sort will be ascending or descending according to what is selected in Sort "Up" / "Down".
