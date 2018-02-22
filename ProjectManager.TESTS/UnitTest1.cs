using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManager.Controllers;
using ProjectManager.BLL.Interfaces;
using ProjectManager.BLL.DTO;
using System.Collections.Generic;
using System.Web.Helpers;

namespace ProjectManager.TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Work_with_Board()
        {
            Mock<IUserService> muser = new Mock<IUserService>();
            Mock<IBoardService> mboard = new Mock<IBoardService>();
            Mock<ITaskListService> mtaskList = new Mock<ITaskListService>();
            Mock<ICardService> mcard = new Mock<ICardService>();

            muser.Setup(m => m.GetById("id")).Returns(new UserDTO { Id = "id", Login = "login" });
            mboard.Setup(m => m.Get(1)).Returns(new BoardDTO { Id = 1, Name = "board" });
            mtaskList.Setup(m => m.Get(1)).Returns(new TaskListDTO { Id = 1, Name = "taskList" });
            mcard.Setup(m => m.Get(1)).Returns(new CardDTO { Id = 1, Name = "card" });

            BoardController board = new BoardController(muser.Object, mboard.Object, mtaskList.Object, mcard.Object);
            Models.BoardViewModel model = new Models.BoardViewModel { Name = "name" };

            int i= model.Id = board.Create("id", model);
            Assert.IsTrue(i != -1);

            model.Name = "nename";
            i = board.Update(model);
            Assert.IsTrue(i != -1);

            i = board.Delete("id", model);
            Assert.IsTrue(i == 0);
        }

        [TestMethod]
        public void Can_Work_with_TaskList()
        {
            Mock<IUserService> muser = new Mock<IUserService>();
            Mock<IBoardService> mboard = new Mock<IBoardService>();
            Mock<ITaskListService> mtaskList = new Mock<ITaskListService>();
            Mock<ICardService> mcard = new Mock<ICardService>();

            muser.Setup(m => m.GetById("id")).Returns(new UserDTO { Id = "id", Login = "login" });
            mboard.Setup(m => m.Get(1)).Returns(new BoardDTO { Id = 1, Name = "board" });
            mtaskList.Setup(m => m.Get(1)).Returns(new TaskListDTO { Id = 1, Name = "taskList" });
            mcard.Setup(m => m.Get(1)).Returns(new CardDTO { Id = 1, Name = "card" });

            TaskListController taskList = new TaskListController(muser.Object, mboard.Object, mtaskList.Object, mcard.Object);
            Models.TaskListViewModel model = new Models.TaskListViewModel { Name = "taskLst" };

            int i = taskList.Create(1, model);
            Assert.IsTrue(i != -1);

            model.Name = "TaSkLisT";
            i = taskList.Update(model);
            Assert.IsTrue(i != -1);

            i = taskList.Delete(1, model);
            Assert.IsTrue(i == 0);
        }

        [TestMethod]
        public void Can_Work_with_Card()
        {
            Mock<IUserService> muser = new Mock<IUserService>();
            Mock<IBoardService> mboard = new Mock<IBoardService>();
            Mock<ITaskListService> mtaskList = new Mock<ITaskListService>();
            Mock<ICardService> mcard = new Mock<ICardService>();

            muser.Setup(m => m.GetById("id")).Returns(new UserDTO { Id = "id", Login = "login" });
            mboard.Setup(m => m.Get(1)).Returns(new BoardDTO { Id = 1, Name = "board" });
            mtaskList.Setup(m => m.Get(1)).Returns(new TaskListDTO { Id = 1, Name = "taskList" });
            mcard.Setup(m => m.Get(1)).Returns(new CardDTO { Id = 1, Name = "card" });

            CardController card = new CardController(muser.Object, mboard.Object, mtaskList.Object, mcard.Object);
            Models.CardViewModel model = new Models.CardViewModel { Name = "card" };

            int i = card.Create(1, model);
            Assert.IsTrue(i != -1);

            model.Name = "NOcard";
            i = card.Update(model);
            Assert.IsTrue(i != -1);

            i = card.Delete(1, model);
            Assert.IsTrue(i == 0);
        }
    }
}
