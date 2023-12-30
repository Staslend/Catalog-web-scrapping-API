
using DataAccessLayer.DataAccess.ActionDbAccess;
using DatabaseLayer.DataContexts;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayerTesting.ActionsAccessTests
{
    public class ActionAccessTest
    {
        [Fact]
        public async void GetURLActions_IdOfExistedURL_ListOfActions()
        {
            //Arrange


            var actionsData = new List<ActionModel>
            {
                new ActionModel
                {
                    action_name = ActionName.Merge,
                    action_data = new List<ActionDataModel>
                    {
                        new ActionDataModel
                        {
                            action_data = "action1Data",
                            action_data_id = 1,
                        }
                    }
                },
                new ActionModel
                {
                    action_name = ActionName.Cut,
                    action_data = new List<ActionDataModel>
                    {
                        new ActionDataModel
                        {
                            action_data = "action2Data",
                            action_data_id = 2,
                        }
                    }
                }
            };


            var URLData = new List<URLModel>
            {
               new URLModel
               {
                    actions = actionsData,
                    url_id = 1,

               }
            }.AsQueryable();

            var URLMock = new Mock<DbSet<URLModel>>();
                        
            URLMock.As<IQueryable<URLModel>>().SetupGet(m => m.Provider).Returns(URLData.Provider);
            URLMock.As<IQueryable<URLModel>>().SetupGet(m => m.Expression).Returns(URLData.Expression);
            URLMock.As<IQueryable<URLModel>>().SetupGet(m => m.ElementType).Returns(URLData.ElementType);
            URLMock.As<IQueryable<URLModel>>().Setup(m => m.GetEnumerator()).Returns(URLData.GetEnumerator());

            var dbContextMock = new Mock<ProductAPIDbContext>();

            dbContextMock.SetupGet(c => c.URLs).Returns(URLMock.Object);


            IActionsDbAccess actionsDbAccess = new ActionsDbAccess(dbContextMock.Object);

            //Act

            List<ActionModel> actions = await actionsDbAccess.GetURLActions(1);

            //Assert
        
            Assert.Equal(2, actions.Count);
            Assert.Equal("action1Data", actions[0].action_data[0].action_data);
            Assert.Equal("action2Data", actions[1].action_data[0].action_data);


        }

        [Fact]
        public async void GetShopActions_IdOfExistedShop_ListOfActions()
        {
            //Arrange


            var actionsData = new List<ActionModel>
            {
                new ActionModel
                {
                    action_name = ActionName.Merge,
                    action_data = new List<ActionDataModel>
                    {
                        new ActionDataModel
                        {
                            action_data = "action1Data",
                            action_data_id = 1,
                        }
                    }
                },
                new ActionModel
                {
                    action_name = ActionName.Cut,
                    action_data = new List<ActionDataModel>
                    {
                        new ActionDataModel
                        {
                            action_data = "action2Data",
                            action_data_id = 2,
                        }
                    }
                }
            };


            var ShopData = new List<ShopModel>
            {
               new ShopModel
               {
                    actions = actionsData,
                    shop_id = 2,

               }
            }.AsQueryable();

            var ShopsMock = new Mock<DbSet<ShopModel>>();

            ShopsMock.As<IQueryable<ShopModel>>().SetupGet(m => m.Provider).Returns(ShopData.Provider);
            ShopsMock.As<IQueryable<ShopModel>>().SetupGet(m => m.Expression).Returns(ShopData.Expression);
            ShopsMock.As<IQueryable<ShopModel>>().SetupGet(m => m.ElementType).Returns(ShopData.ElementType);
            ShopsMock.As<IQueryable<ShopModel>>().Setup(m => m.GetEnumerator()).Returns(ShopData.GetEnumerator());

            var dbContextMock = new Mock<ProductAPIDbContext>();

            dbContextMock.SetupGet(c => c.shops).Returns(ShopsMock.Object);


            IActionsDbAccess actionsDbAccess = new ActionsDbAccess(dbContextMock.Object);

            //Act

            List<ActionModel> actions = await actionsDbAccess.GetShopActions(2);

            //Assert

            Assert.Equal(2, actions.Count);
            Assert.Equal("action1Data", actions[0].action_data[0].action_data);
            Assert.Equal("action2Data", actions[1].action_data[0].action_data);


        }
    
    
    }
}