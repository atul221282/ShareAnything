using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Model
{
    [DataContract]
    public class PostModel
    {
        [DataMember, Required]
        public string Name { get; set; }
    }


    public class Rootobject
    {
        public Shareanythingposttypetransportlist[] ShareAnythingPostTypeTransportList { get; set; }
        public Shareanythingposttransportlist[] ShareAnythingPostTransportList { get; set; }
        public object Claims { get; set; }
        public object SuccessMessage { get; set; }
        public object NavigateToUrl { get; set; }
        public object Warning { get; set; }
        public object CreatedBy { get; set; }
        public object UserId { get; set; }
        public object Id { get; set; }
        public object RowVersion { get; set; }
    }

    public class Shareanythingposttypetransportlist
    {
        public int SortOrder { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Id { get; set; }
        public string AuditCreatedBy { get; set; }
        public string AuditLastUpdatedBy { get; set; }
        public DateTime? AuditCreatedDate { get; set; }
        public DateTime? AuditLastUpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int EntityState { get; set; }
        public string RowVersion { get; set; }
    }

    public class Shareanythingposttransportlist
    {
        public Addresstransport AddressTransport { get; set; }
        public int ShareAnythingPostTypeId { get; set; }
        public string ShareAnythingPostTypeCode { get; set; }
        public Shareanythingpostlink ShareAnythingPostLink { get; set; }
        public File[] Files { get; set; }
        public string Details { get; set; }
        public bool IsVisible { get; set; }
        public int TotalLikes { get; set; }
        public string FormattedLikes { get; set; }
        public DateTime CreateDate { get; set; }
        public int TotalComments { get; set; }
        public string FormattedComments { get; set; }
        public Postedby PostedBy { get; set; }
        public bool ShowMore { get; set; }
        public bool HasLikedByUser { get; set; }
        public object PostComments { get; set; }
        public object Comment { get; set; }
        public bool IsFlipped { get; set; }
        public object Claims { get; set; }
        public object SuccessMessage { get; set; }
        public object NavigateToUrl { get; set; }
        public object Warning { get; set; }
        public object CreatedBy { get; set; }
        public object UserId { get; set; }
        public int Id { get; set; }
        public string RowVersion { get; set; }
    }

    public class Addresstransport
    {
        public string AddressLine1 { get; set; }
        public object AddressLine2 { get; set; }
        public string City { get; set; }
        public object Suburb { get; set; }
        public string State { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public Countrytransport CountryTransport { get; set; }
        public object Claims { get; set; }
        public object SuccessMessage { get; set; }
        public object NavigateToUrl { get; set; }
        public object Warning { get; set; }
        public object CreatedBy { get; set; }
        public object UserId { get; set; }
        public int Id { get; set; }
        public object RowVersion { get; set; }
    }

    public class Countrytransport
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public object Claims { get; set; }
        public object SuccessMessage { get; set; }
        public object NavigateToUrl { get; set; }
        public object Warning { get; set; }
        public object CreatedBy { get; set; }
        public object UserId { get; set; }
        public int Id { get; set; }
        public string RowVersion { get; set; }
    }

    public class Shareanythingpostlink
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string AuditCreatedBy { get; set; }
        public string AuditLastUpdatedBy { get; set; }
        public DateTime AuditCreatedDate { get; set; }
        public DateTime AuditLastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int EntityState { get; set; }
        public string RowVersion { get; set; }
    }

    public class Postedby
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public bool CanContactUsers { get; set; }
        public object UserProfileImage { get; set; }
        public object File { get; set; }
        public object[] Roles { get; set; }
        public Addresstransport1 AddressTransport { get; set; }
        public object EmailAddress { get; set; }
        public object CreateDate { get; set; }
        public object Claims { get; set; }
        public object SuccessMessage { get; set; }
        public object NavigateToUrl { get; set; }
        public object Warning { get; set; }
        public object CreatedBy { get; set; }
        public object UserId { get; set; }
        public int Id { get; set; }
        public object RowVersion { get; set; }
    }

    public class Addresstransport1
    {
        public object AddressLine1 { get; set; }
        public object AddressLine2 { get; set; }
        public object City { get; set; }
        public object Suburb { get; set; }
        public object State { get; set; }
        public object Province { get; set; }
        public object PostalCode { get; set; }
        public object CountryTransport { get; set; }
        public object Claims { get; set; }
        public object SuccessMessage { get; set; }
        public object NavigateToUrl { get; set; }
        public object Warning { get; set; }
        public object CreatedBy { get; set; }
        public object UserId { get; set; }
        public object Id { get; set; }
        public object RowVersion { get; set; }
    }

    public class File
    {
        public int Length { get; set; }
        public string ContentType { get; set; }
        public string UniqueFileName { get; set; }
        public object Data { get; set; }
        public string OriginalFileName { get; set; }
        public string OriginalFileExtension { get; set; }
        public string Title { get; set; }
        public bool IsUploaded { get; set; }
        public bool IsMarkedForDeletion { get; set; }
        public bool IsValidFileType { get; set; }
        public string FormattedImageUrl { get; set; }
        public int Id { get; set; }
        public string AuditCreatedBy { get; set; }
        public string AuditLastUpdatedBy { get; set; }
        public DateTime AuditCreatedDate { get; set; }
        public DateTime AuditLastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int EntityState { get; set; }
        public string RowVersion { get; set; }
    }


}
