﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;
using RippLib.Readability;

namespace RippLib.Util.Tests;

public class EmptyTests
{
    public class Lists
    {
        [Fact]
        public void Null_value_should_return_true()
        {
            var nullList = (List<object>)null;
            var result = nullList.Empty();
            result.Should().BeTrue();
        }

        [Fact]
        public void Newly_initialized_without_values_should_return_true()
        {
            var emptyList = new List<object>();
            var result = emptyList.Empty();
            result.Should().BeTrue();
        }

        [Fact]
        public void Newly_initialized_with_single_value_should_return_false()
        {
            var listWithValues = new List<object>() { new() };
            var result = listWithValues.Empty();
            result.Should().BeFalse();
        }

        [Fact]
        public void Newly_initialized_with_multiple_values_should_return_false()
        {
            var listWithValues = new List<object>() { new(), new() };
            var result = listWithValues.Empty();
            result.Should().BeFalse();
        }

        [Fact]
        public void Searching_for_non_existing_value_should_return_true()
        {
            var listWithValues = new List<string>() { "not so empty string", "another not so empty string" };
            var result = listWithValues.Empty(x => x.StartsWith("none existing value"));
            result.Should().BeTrue();
        }

        [Fact]
        public void Searching_for_existing_value_should_return_false()
        {
            var listWithValues = new List<string>() { "not so empty string", "another not so empty string" };
            var result = listWithValues.Empty(x => x.StartsWith("not"));
            result.Should().BeFalse();
        }
    }

    public class Arrays
    {
        [Fact]
        public void Null_value_should_return_true()
        {
            var nullArray = (object[])null;
            var result = nullArray.Empty();
            result.Should().BeTrue();
        }

        [Fact]
        public void Newly_initialized_without_values_should_return_true()
        {
            var emptyArray = Array.Empty<object>();
            var result = emptyArray.Empty();
            result.Should().BeTrue();
        }

        [Fact]
        public void Newly_initialized_without_value_but_defined_size_should_return_false()
        {
            var arrayWithValues = new object[1];
            var result = arrayWithValues.Empty();
            result.Should().BeFalse();
        }

        [Fact]
        public void Newly_initialized_with_single_value_should_return_false()
        {
            var arrayWithValues = new object[1] { new() };
            var result = arrayWithValues.Empty();
            result.Should().BeFalse();
        }

        [Fact]
        public void Newly_initialized_with_multiple_values_should_return_false()
        {
            var arrayWithValues = new object[2] { new(), new() };
            var result = arrayWithValues.Empty();
            result.Should().BeFalse();
        }

        [Fact]
        public void Searching_for_non_existing_value_should_return_true()
        {
            var arrayWithValues = new string[2] { "not so empty string", "another not so empty string" };
            var result = arrayWithValues.Empty(x => x.StartsWith("none existing value"));
            result.Should().BeTrue();
        }

        [Fact]
        public void Searching_for_existing_value_should_return_false()
        {
            var arrayWithValues = new string[2] { "not so empty string", "another not so empty string" };
            var result = arrayWithValues.Empty(x => x.StartsWith("not"));
            result.Should().BeFalse();
        }
    }

    public class Enumerable
    {
        [Fact]
        public void Newly_initialized_without_values_should_return_true()
        {
            var emptyEnumerable = new Collection<object>().AsEnumerable();
            var result = emptyEnumerable.Empty();
            result.Should().BeTrue();
        }

        [Fact]
        public void Newly_initialized_with_single_value_should_return_false()
        {
            var enumerableWithValues = new Collection<object>() { new() }.AsEnumerable();
            var result = enumerableWithValues.Empty();
            result.Should().BeFalse();
        }

        [Fact]
        public void Newly_initialized_with_multiple_values_should_return_false()
        {
            var enumerableWithValues = new Collection<object>() { new(), new() }.AsEnumerable();
            var result = enumerableWithValues.Empty();
            result.Should().BeFalse();
        }

        [Fact]
        public void Searching_for_non_existing_value_should_return_true()
        {
            var enumerableWithValues = new Collection<string>() { "not so empty string", "another not so empty string" }.AsEnumerable();
            var result = enumerableWithValues.Empty(x => x.StartsWith("none existing value"));
            result.Should().BeTrue();
        }

        [Fact]
        public void Searching_for_existing_value_should_return_false()
        {
            var enumerableWithValues = new List<string>() { "not so empty string", "another not so empty string" }.AsEnumerable();
            var result = enumerableWithValues.Empty(x => x.StartsWith("not"));
            result.Should().BeFalse();
        }
    }
}
