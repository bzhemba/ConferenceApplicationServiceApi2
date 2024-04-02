using ApplicationsService.Abstractions.Domain;
using ApplicationsService.Domain.Entities;
using ApplicationsService.Domain.ValueObjects;

namespace ApplicationsService.Domain.Events;

public record ApplicationSubmitted(ApplicationsList List, Application Application) :IDomainEvent;