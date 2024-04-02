using ApplicationsService.Abstractions.Domain;
using ApplicationsService.Domain.Events;
using ApplicationsService.Domain.Exceptions;
using ApplicationsService.Domain.ValueObjects;
using ApplicationId = ApplicationsService.Domain.ValueObjects.ApplicationId;

namespace ApplicationsService.Domain.Entities;

public class ApplicationsList : AggregateRoot<ApplicationId>
    {
        public ApplicationId Id { get; private set; }
        

        private readonly LinkedList<Application> _items = new();
        
        private ApplicationsList(ApplicationId id, LinkedList<Application> items)
            : this(id)
        {
            _items = items;
        }

        private ApplicationsList()
        {
        }

        internal ApplicationsList(ApplicationId id)
        {
            Id = id;
        }

        public void AddApplication(Application item)
        {
            var alreadyExists = _items.Any(i => (i.UserId == item.UserId) && (i.WasSentStatus == false));

            if (alreadyExists)
            {
                throw new ApplicationDraftAlreadyExistsException(item.Id);
            }

            _items.AddLast(item);
            AddEvent(new ApplicationAdded(this, item));
        }

        public void RemoveItem(Guid id)
        {
            var item = GetItem(id);
            _items.Remove(item);
            AddEvent(new ApplicationRemoved(this, item));
        }

        private Application GetItem(Guid id)
        {
            var item = _items.SingleOrDefault(i => i.Id == id);

            if (item is null)
            {
                throw new ApplicationNotFoundException(id);
            }

            return item;
        }
        public void SubmitApplication(Guid id)
        {
            var application = GetItem(id);
            var submittedApplication = application;
            submittedApplication.ChangeStatus();

            _items.Find(application).Value = submittedApplication;
            AddEvent(new ApplicationSubmitted(this, application));
        }
    }