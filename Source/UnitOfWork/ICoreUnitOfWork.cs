﻿using System.Threading.Tasks;
using IMAS.Model.Domain.Core;
using IMAS.Repository;

namespace IMAS.UnitOfWork
{
    public interface ICoreUnitOfWork
    {
        GenericRepository<Comment> CommentRepository { get; }
        GenericRepository<Content> ContentRepository { get; }
        GenericRepository<ForbiddenIdentifier> ForbiddenIdentifierRepository { get; }
        GenericRepository<Reference> ReferenceRepository { get; }
        GenericRepository<Role> RoleRepository { get; }
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Tag> TagRepository { get; }
        GenericRepository<Location> LocationRepository { get; }
        GenericRepository<Rate> RateRepository { get; }
        GenericRepository<Membership> MembershipRepository { get; }
        GenericRepository<Visit> VisitRepository { get; }
        GenericRepository<Profile> ProfileRepository { get; }
        GenericRepository<ExceptionLog> ExceptionLogRepository { get; }
        GenericRepository<Publication> PublicationRepository { get; }
        GenericRepository<Blog> BlogRepository { get; }
        GenericRepository<Channel> ChannelRepository { get; }
        GenericRepository<BlogLink> FriendRepository { get; }
        GenericRepository<Notification> NotificationRepository { get; }
        GenericRepository<Organization> OrganizationRepository { get; }
        GenericRepository<UniversityField> UniversityFieldRepository { get; }
        GenericRepository<EducationalResume> EducationalResumeRepository { get; }
        GenericRepository<Job> JobRepository { get; }
        GenericRepository<JobResume> JobResumeRepository { get; }
        GenericRepository<Media> MediaRepository { get; }
        GenericRepository<Follow> FollowRepository { get; }
        GenericRepository<Message> MessageRepository { get; }
        GenericRepository<FeaturedContent> FeaturedContentRepository { get; }
        GenericRepository<Picture> PictureRepository { get; }
        GenericRepository<AdvertismentVisit> AdvertismentVisitRepository { get; }

        GenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();
    }
}