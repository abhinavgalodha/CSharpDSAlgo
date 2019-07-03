## 7/2/2019

### Unit Testing

#### Theory and Inline Data
Found the usefulness of using the Xunit `Theory` and `InlineData` attributes.
Rather than creating multiple tests with same code and validation, we can optimize by using the Theory and the Inline Data attribute

*These are helpful when we want to use multiple data for the tests and create only one test method.*

##### Before using Inline Data

```

        public void CreateABinaryNodeWith2Values()
        {
            List<int> listInputNumbers = new List<int>() {1,2};
            var binaryNode = BinaryNode<int>.CreateABinaryNode(listInputNumbers.ToArray());
            var result = binaryNode.TraverseInOrder();
            result.Should().BeEquivalentTo(listInputNumbers);
        }

        [Fact]
        public void CreateABinaryNodeWith3Values()
        {
            List<int> listInputNumbers = new List<int>() {2,1,3};
            var binaryNode = BinaryNode<int>.CreateABinaryNode(listInputNumbers.ToArray());
            var result = binaryNode.TraverseInOrder();
            result.Should().BeEquivalentTo(listInputNumbers);
        }

        [Fact]
        public void CreateABinaryNodeWith5Values()
        {
            List<int> listInputNumbers = new List<int>() {3,4,2,1,5};
            var binaryNode = BinaryNode<int>.CreateABinaryNode(listInputNumbers.ToArray());
            var result = binaryNode.TraverseInOrder();
            result.Should().BeEquivalentTo(listInputNumbers);
        }
```

##### After Change

```

```



