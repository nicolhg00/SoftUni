using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault vault;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
        }

        [Test]
        public void AddItem_ThrowAnExceptionWhenCellDoesNotExists()
        {
            Item item = new Item("Ivo", "1");

            Assert.Throws<ArgumentException>(() => vault.AddItem("No such sell", item));
        }

        [Test]
        public void AddItem_ThrowAnExceptionWhenAlreadyTaken()
        {
            Item item = new Item("Ivo", "1");

            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", new Item("Ivo", "25")));
        }

        [Test]
        public void AddItem_ThrowAnExceptionWhenAlreadyInACell()
        {
            Item item = new Item("Ivo", "1");

            vault.AddItem("A1", item);

            Item newItem = new Item("Pesho", "1");

            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A2", newItem));
        }

        [Test]
        public void AddItem_AddsItemToTheVault()
        {
            Item item = new Item("Ivo", "1");

            vault.AddItem("A1", item);

            Assert.That(item, Is.EqualTo(vault.VaultCells["A1"]));
        }

        [Test]
        public void AddItem_ReturnsString()
        {
            Item item = new Item("Ivo", "1");

            string expected = $"Item:{item.ItemId} saved successfully!";

            string actual = vault.AddItem("A1", item);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveMethodThrowsAnExceptionWhenItemDoesNotExist()
        {
            Item item = new Item("Ivo", "1");

            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A2", item));
        }

        [Test]
        public void RemoveMethodRemovesItem()
        {
            Item item = new Item("Ivo", "1");

            vault.AddItem("A1", item);

            vault.RemoveItem("A1", item);

            Assert.That(vault.VaultCells["A1"], Is.Null);
        }

        [Test]
        public void RemoveMethodReturnsString()
        {
            Item item = new Item("Ivo", "1");

            vault.AddItem("A1", item);

            string expected = $"Remove item:{item.ItemId} successfully!";

            string actual = vault.RemoveItem("A1", item);

            Assert.AreEqual(expected, actual);
        }
    }

}