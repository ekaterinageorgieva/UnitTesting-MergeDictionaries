using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class MergeDictionariesTests
{
    [Test]
    public void Test_Merge_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary< string, int> dict2 = new Dictionary<string, int>();

        // Act
        var result = MergeDictionaries.Merge(dict1 , dict2 );

        // Assert
        Assert.That( result, Is.Empty );


    }

    [Test]
    public void Test_Merge_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsNonEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            {"peppers", 18 },
            { "tomatos", 24}
        };
        Dictionary<string, int> expectedResult = new Dictionary<string, int>() 
        {
            {"peppers", 18 },
            { "tomatos", 24}
        }; ;

        // Act
        var result = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_Merge_TwoNonEmptyDictionaries_ReturnsMergedDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
           { "kiwi", 32 }
        };
        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            {"peppers", 18 },
            { "tomatos", 24}
        };
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            {"peppers", 18 },
            { "tomatos", 24},
            { "kiwi", 32 }
        }; ;

        // Act
        var result = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Merge_OverlappingKeys_ReturnsMergedDictionaryWithValuesFromDict2()
    { 
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
           { "kiwi", 32 },
            {"peppers", 18 },
            { "tomatos", 24}
        };
        Dictionary<string, int> dict2 = new Dictionary<string, int>()
        {
            {"peppers", 18 },
            { "tomatos", 24}
        };
        Dictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            {"peppers", 18 },
            { "tomatos", 24},
            { "kiwi", 32 }
        }; ;

        // Act
        var result = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
