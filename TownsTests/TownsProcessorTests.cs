using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towns;

namespace TownsTests
{
    public class TownsProcessorTests
    {
        [Test]
        public void Test_ExecuteCommand_InvalidOperation()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var actual = townProcessor.ExecuteCommand("Alabala");

            //Assert
            Assert.That(actual, Is.EqualTo("Invalid command: Alabala"));
        }
        [Test]
        public void Test_ExecuteCommand_CREATE()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var createCommand = "CREATE Paris, London";
            var actual = townProcessor.ExecuteCommand(createCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Successfully created collection of towns."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }
        [Test]
        public void Test_ExecuteCommand_PRINT()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var printCommnad = "PRINT";

            var actual = townProcessor.ExecuteCommand(printCommnad);

            //Assert
            Assert.That(actual, Is.EqualTo("Towns: Paris, London"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }
        [Test]
        public void Test_ExecuteCommand_ADD()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommnad = "ADD Sofia";

            var actual = townProcessor.ExecuteCommand(addCommnad);

            //Assert
            Assert.That(actual, Is.EqualTo("Successfully added: Sofia"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
        }
        [Test]
        public void Test_ExecuteCommand_TryADDExisting()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommnad = "ADD London";

            var actual = townProcessor.ExecuteCommand(addCommnad);

            //Assert
            Assert.That(actual, Is.EqualTo("Cannot add: London"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }
        [Test]
        public void Test_ExecuteCommandREVERSE()
        {
            //Arange
            var townProcessor = new TownsProcessor();
            //Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var reverseCommand = "REVERSE Paris, London";

            var actual = townProcessor.ExecuteCommand(reverseCommand);
            //Assert
            Assert.That(actual, Is.EqualTo("Collection of towns reversed."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }
        [Test]
        public void Test_ExecuteCommand_Reverse_InvalidOperationException()
        {
            //Arange
            var townProcessor = new Towns.TownsProcessor();
            //Act
            var reverseCommand = "REVERSE Paris";
            var actual = townProcessor.ExecuteCommand(reverseCommand);
            Assert.That(actual, Is.EqualTo("Cannot reverse a collection of towns with less than 2 items."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(0));

        }
        //Error
        //[Test]
        //public void Test_TownProcessor_Reverse_Null()
        //{
        //    var townProcessor = new TownsProcessor();
        //    var createCommand = townProcessor.ExecuteCommand("CREATE");
        //    townProcessor.Towns = null;//error
        //    var reverseCommand = townProcessor.ExecuteCommand("REVERSE");

        //    Assert.That(reverseCommand, Is.EqualTo("Cannot reverse a null collection of towns."));
        //}


        [Test]
        public void Test_TownProcessor_Remove_ValidIndex()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = townProcessor.ExecuteCommand("CREATE London, Sofia");
            var removeCommand = townProcessor.ExecuteCommand("REMOVE 0");

            Assert.That(removeCommand, Is.EqualTo("Successfully removed from index: 0"));
        }

        [Test]
        public void Test_RemoveAtTown_verifyRemovedCorrect()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = "CREATE Lisbon, Roma, Sofia";

            townProcessor.ExecuteCommand(createCommand);
            var removeTown = "REMOVE 1";

            var actualResult = townProcessor.ExecuteCommand(removeTown);
            //var printInput = "PRINT";


            Assert.That(actualResult, Is.EqualTo("Successfully removed from index: 1"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }
        [Test]
        public void Test_RemoveAtTown_verifyRemovedNotCorrect()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = "CREATE Lisbon, Roma, Sofia";

            townProcessor.ExecuteCommand(createCommand);
            var removeTown = "REMOVE 3";

            var actualResult = townProcessor.ExecuteCommand(removeTown);
            //var printInput = "PRINT";


            Assert.That(actualResult, Is.EqualTo("Invalid operation."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
        }
    }
}

