using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Entities.Logger
{
  public  class loggerMessageDisplay
    {
     // Apetisani Messages
        public const string BooksListed = "All Apetisani listed successfully!";
        public const string NoBooksInDB = "There is no Apetisani in the DB!";
        public const string BookFoundDisplayDetails = "Apetisani was found in the DB, show the details of the Apetisani";
        public const string NoBookFound = "This is no book found in the DB!";
        public const string BookCreated = "New book is created in the DB";
        public const string BookNotCreatedModelStateInvalid = "New book is NOT created in the DB, ModelState is not valid";
        public const string BookEdited = "Book is edited successfully";
        public const string BookEditNotFound = "Book for editting is not found in the DB";
        public const string BookEditErrorModelStateInvalid = "Book is not edited, ModelState is not valid";
        public const string BookDeleted = "Book is deleted successfully";
        public const string BookDeletedError = "Book is NOT deleted, error happend in process of deletion";

   // Coffe Messages
        public const string PublishersListed = "All publishers listed successfully!";
        public const string NoPublishersInDB = "There is no publishers in the DB!";
        public const string PublisherFoundDisplayDetails = "Publisher was found in the DB, show the details of the publisher";
        public const string NoPublisherFound = "This is no publisher found in the DB!";
        public const string PublisherCreated = "New publisher is created in the DB";
        public const string PublisherNotCreatedModelStateInvalid = "New publisher is NOT created in the DB, ModelState is not valid";
        public const string PublisherEdited = "Publisher is edited successfully";
        public const string PublisherEditNotFound = "Publisher for editting is not found in the DB";
        public const string PublisherEditErrorModelStateInvalid = "Publisher is not edited, ModelState is not valid";
        public const string PublisherDeleted = "Publisher is deleted successfully";
        public const string PublisherDeletedError = "Publisher is NOT deleted, error happend in process of deletion";

        // Candy Messages
        public const string AuthorsListed = "All authors listed successfully!";
        public const string NoAuthorsInDB = "There is no authors in the DB!";
        public const string AuthorFoundDisplayDetails = "Author was found in the DB, show the details of the author";
        public const string NoAuthorFound = "This is no author found in the DB!";
        public const string AuthorCreated = "New author is created in the DB";
        public const string AuthorNotCreatedModelStateInvalid = "New author is NOT created in the DB, ModelState is not valid";
        public const string AuthorEdited = "Author is edited successfully";
        public const string AuthorEditErrorModelStateInvalid = "Author is not edited, ModelState is not valid";
        public const string AuthorDeleted = "Author is deleted successfully";
        public const string AuthorDeletedError = "Author is NOT deleted, error happend in process of deletion";


        // Upload Photo Messages
        public const string PhotoUploaded = "Photo is successfully uploaded";
        public const string PhotoUploadedError = "Photo is NOT uploaded";
        public const string PhotosListed = "All photos listed successfully!";
        public const string NoPhotosInDB = "There is no photos in the DB!";
        public const string PhotoFoundDisplayDetails = "Photo was found in the DB, show the details of the photo";
        public const string NoPhotoFound = "This is no photo found in the DB!";
        public const string PhotoCreated = "New photo is created in the DB";
        public const string PhotoNotCreatedModelStateInvalid = "New photo is NOT created in the DB, ModelState is not valid";
        public const string PhotoEdited = "Photo is edited successfully";
        public const string PhotoEditErrorModelStateInvalid = "Photo is not edited, ModelState is not valid";
        public const string PhotoDeleted = "Photo is deleted successfully";
        public const string PhotoDeletedError = "Photo is NOT deleted, error happend in process of deletion";

        // User Messages
        public const string UsersListed = "All users listed successfully!";
        public const string NoUsersInDB = "There is no user in the DB!";
        public const string UserFoundDisplayDetails = "User was found in the DB, show the details of the user";
        public const string NoUserFound = "There is no user found in the DB!";
        public const string UserCreated = "New user is created in the DB";
        public const string UserNotCreatedModelStateInvalid = "New user is NOT created in the DB, ModelState is not valid";
        public const string UserEdited = "User is edited successfully";
        public const string UserEditErrorModelStateInvalid = "User is not edited, ModelState is not valid";
        public const string UserDeleted = "User is deleted successfully";
        public const string UserDeletedError = "User is NOT deleted, error happend in process of deletion";
        public const string UserAddedRole = "User added to Role";
    }
}
