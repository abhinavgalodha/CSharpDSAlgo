# Tree

## Inheritance - What kind of inheritance should be create in Nodes

Abstract Node  
 |      
Leaf Node  
 |  
Binary Node

## Inheritance - What kind of inheritance should be create in Tree

Abstract Node  
 |      
Binary Node


## The case of using Logic with setters in OOPS

### Problem

`BinaryNode` contains property for Left/Right Node.  The setter is a private setter, which allows the value of Left/Right node to be set.
However, for a BST, Invariants Should be met which is 
** Left Node < Value < Right Node **

Therefore, we need to make sure that the Left/Right Node be set to appropriate values.
We will use the language construct of properties with setter to make sure that the invariants are met..

### Current Implementation

`public BinaryNode<T>? LeftNode {get; private set;}`

### Proposed implementation


```
        // TODO: Add a operator to simplify the comparison or working on LeftNode.Value with value. operator overloading..
        public BinaryNode<T>? LeftNode
        {
            get => m_LeftNode;
            private set
            {
                value.ThrowIfNull("LeftNode");

                if (!IsBSTInvariantMet(this, value.Value, BinaryNodePosition.Left))
                {
                    throw new ArgumentException("The value of the left node has to be less than of the Parent Node");
                };

                m_LeftNode = value;
            }
        }
```   

## TODO : Should LeftNode and RightNode be seperate classes as both have a defining invariants

## TODO : Is there a generic implementation of a class with the Inverse Relationship

e.g left node is the inverse of the right node, So define a class and then have an inverse representation of the same class