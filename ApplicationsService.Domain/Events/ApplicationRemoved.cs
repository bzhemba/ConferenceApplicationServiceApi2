using ApplicationsService.Abstractions.Domain;
using ApplicationsService.Domain.Entities;
using ApplicationsService.Domain.ValueObjects;

namespace ApplicationsService.Domain.Events;

public record ApplicationRemoved(ApplicationsList List, Application Application) :IDomainEvent;