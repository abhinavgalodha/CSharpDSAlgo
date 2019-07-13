## What should be the naming convention for the Tests?

### Convention

Should[expected]_When[condition]

e.g. Should_FailToWithdrawMoney_ForInvalidAccount


## Adding Traits on the class rather than on the individual tests

### What to Do?

* Trait applied at class level.


### Benefits

* Write less code.
* Reuse the information from one class to other classes.

### Before

* Trait applied at method level.

```
[Fact]
[Trait("Category", "BST")]
[Trait("Category", "Min")]
public void Should_ReturnMinAsRoot_WhenOnlyElementIsRoot()
{
    // Act
    BinarySearchTree<int> bst = new BinarySearchTree<int>(5);

    // Assert
    bst.Minimum().Should().Be(5);
}

```

### After

* Trait applied at class level.
* *No* Trait applied at method level.

```
[Trait("Category", "BST")]
[Trait("Category", "Min")]
public partial class BinaryTreeTest
{
    [Fact]
    public void Should_ReturnMinAsRoot_WhenOnlyElementIsRoot()
    {
        // Act
        BinarySearchTree<int> bst = new BinarySearchTree<int>(5);

        // Assert
        bst.Minimum().Should().Be(5);
    }
}

```

## Splitting the code for a test class among multiple classes using partial classes

### Problem?
* The test class file gets too long with all the tests.

### What to do?
* Split the test into the multiple files using partial classes.


