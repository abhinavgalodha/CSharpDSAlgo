# Learnings

## Char

* When storing the `Char` need to consider the surrogate pair. A surrogate pair needs two UTF-16 to store the data. For e.g. the Emoji need to use the Surrogate pair.
* If we need to convert the char to integer, then need to understand the right methods to convert the data.

## Number
* Check for overflow when dealing with numbers.


## Debugging
Using the `DebuggerDisplay` attribute to decorate a class to easily a complex class expression

```
// Adding the debugger display for easier debugging
    [DebuggerDisplay("NodeValue={Value}")]
    public abstract class BaseNode<T>
```

