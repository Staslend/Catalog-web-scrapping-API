
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
        ActionAccessTest() { }

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        [Fact]
        public void GetURLActions_IdOfExistedURL_ListOfActions()
        {
            //Arrange

            ProductAPIDbContext dbContextMock = new ProductAPIDbContext();

            IActionsDbAccess actionsDbAccess = new ActionsDbAccess(dbContextMock);


            var moqSet = GetQueryableMockDbSet<URLModel>(new List<URLModel>
            {
                new URLModel
                {
                    actions = new List<ActionModel>
                    {
                        new ActionModel
                        {
                            action_id = 1,
                            action_data = {new ActionDataModel()},
                            action_name = ActionName.Cut
                        },
                        new ActionModel
                        {
                            action_id = 2,
                            action_data = {new ActionDataModel()},
                            action_name = ActionName.Merge
                        },
                        new ActionModel
                        {
                            action_id = 3,
                            action_data = {new ActionDataModel()},
                            action_name = ActionName.ConvertToNumeric
                        },

                    }
                }
            });

            var dbContextMoq = new Mock<ProductAPIDbContext>();
            dbContextMoq.Setup(x => x.Set<URLModel>()).Returns(moqSet);



            //Act

            List<ActionModel> actions = dbContextMoq.URLs.ToList();

            //Assert
        }
    }
}