using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZBW.PEAII_Nuget_DatenLogger.UnitTest
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestClass]
        public class UserRepositoryTests
        {
            /*
            private List<User> persistedUsers = new List<User>();
            private UserRepository userRepository;

            [TestInitialize]
            public void Setup()
            {
                Mock<IPersistenceService> persistenceMock = new Mock<IPersistenceService>();

                persistenceMock.Setup(service => service.Save(It.IsAny<object>())).Callback<object>(
                    item =>
                    {
                        (item as IInstanceIdentifier).Id = persistedUsers.Count() + 1;
                        persistedUsers.Add(item as User);
                    }
                );

                persistenceMock.Setup
                    (
                        service => service.GetById<User>(It.IsAny<long>())
                    )
                    .Returns<long>
                    (
                        item => persistedUsers.Where(user => user.Id == item).FirstOrDefault()
                    );

                persistenceMock.Setup(service => service.GetAll<User>()).Returns(persistedUsers);

                userRepository = new UserRepository(persistenceMock.Object);
            }

            [TestMethod]
            public void it_should_be_possible_to_add_a_new_user()
            {
                long expectedUserId = 1;

                var user = new User
                {
                    Username = "firstuser",
                    FirstName = "Norbert",
                    LastName = "Eder",
                    Password = "firstuser"
                };

                userRepository.SaveOrUpdate(user);

                var persistedUser = userRepository.GetUserById(1);

                Assert.IsNotNull(persistedUser, "User was not persisted, otherwise it shouldn't be null");
                Assert.AreEqual<long>(expectedUserId, persistedUser.Id);
            }

            [TestMethod]
            public void username_eder_should_be_infront_of_maier()
            {
                int expectedListCount = 2;
                string expectedFirstUsername = "eder";
                string expectedSecondUnsername = "maier";

                var maierUser = new User
                {
                    Username = "maier"
                };

                var ederUser = new User
                {
                    Username = "eder"
                };

                userRepository.SaveOrUpdate(maierUser);
                userRepository.SaveOrUpdate(ederUser);

                var users = userRepository.GetUsersSortedByUsername();

                Assert.AreEqual<int>(expectedListCount, users.Count());
                Assert.AreEqual<string>(expectedFirstUsername, users[0].Username);
                Assert.AreEqual<string>(expectedSecondUnsername, users[1].Username);
            }*/
        }
    }
}