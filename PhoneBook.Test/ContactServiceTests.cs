using Moq;
using PhoneBook.Application.Interfaces;
using PhoneBook.Application.Services;
using PhoneBook.Domain;
using PhoneBook.Domain.Repositories;

namespace PhoneBook.Test
{
    [TestFixture]
    public class ContactServiceTests
    {
        private IContactService _contactService;
        private Mock<IContactRepository> _contactRepository;

        [SetUp]
        public void Setup()
        {
            _contactRepository = new Mock<IContactRepository>();
            _contactService = new ContactService(_contactRepository.Object);
        }

        [Test]
        public void GetContactById_ExistingId_ReturnsContact()
        {
            int contactId = 1;
            var expectedContact = new Contact { Id = contactId, Name = "John Doe" };
            _contactRepository.Setup(r => r.GetById(contactId)).Returns(expectedContact);

            var result = _contactService.GetContactById(contactId);
            Assert.AreEqual(expectedContact, result);
        }

        [Test]
        public void CreateContact_ValidContact_CallsRepositoryAdd()
        {
            var contactToAdd = new CreateContact { Id = 1, Name = "John Doe" };
            _contactService.CreateContact(contactToAdd);
            _contactRepository.Verify(r => r.Add(contactToAdd), Times.Once);
        }

        [Test]
        public void UpdateContact_ValidContact_CallsRepositoryUpdate()
        {
            var contactToUpdate = new UpdateContact { Id = 1, Name = "John Doe", PhoneNumber = "09378154" };
            _contactService.UpdateContact(contactToUpdate);
            _contactRepository.Verify(r => r.Update(contactToUpdate), Times.Once);
        }

        [Test]
        public void DeleteContact_ExistingId_CallsRepositoryDelete()
        {
            int contactId = 1;
            _contactService.DeleteContact(contactId);
            _contactRepository.Verify(r => r.Delete(contactId), Times.Once);
        }
    }
}