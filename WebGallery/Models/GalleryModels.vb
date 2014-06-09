Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Gallery
    <Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)> Public Property GalleryID As Long
    Public Property Name As String
    Public Property Created As DateTime
    Public Overridable Property Owner As ApplicationUser
    Public Overridable Property Permissions As ICollection(Of GalleryPermission)
End Class

Public Class GalleryPermission
    <Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)> Public Property GalleryPermissionID As Long
    Public Overridable Property Gallery As Gallery
    Public Overridable Property UserGroup As UserGroup
    Public Property AllowAdd As Boolean
    Public Property AllowDelete As Boolean
    Public Property AllowComment As Boolean
    Public Property AllowDeleteOwn As Boolean
    Public Property AllowModeration As Boolean
End Class

Public Class UserGroup
    <Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)> Public Property UserGroupID As Long
    Public Property Name As String
    Public Overridable Property Owner As ApplicationUser
    Public Overridable Property Members As ICollection(Of ApplicationUser)
End Class

Public Class Media
    <Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)> Public Property MediaID As Long
    Public Property Name As String
    Public Overridable Property Owner As ApplicationUser

    Public Overridable Property Tags As ICollection(Of Tag)
    Public Overridable Property Comments As ICollection(Of Comment)
    Public Property BlobContainer As String
    Public Property BlobName As String
End Class

Public Class PublishMedia
    <Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)> Public Property PublishMedia As Long
    Public Overridable Property Media As Media
    Public Overridable Property Gallery As Gallery
    Public Overridable Property ModeratedBy As ApplicationUser
    Public Property Moderated As Boolean = False
    Public Property ModeratedDate As DateTime
    Public Property PublishDate As DateTime
End Class

Public Class Tag
    <Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)> Public Property TagID As Long
    Public Property Name As String
    Public Overridable Property Media As ICollection(Of Media)
End Class

Public Class Comment
    <Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)> Public Property CommentID As Long
    Public Overridable Property Owner As ApplicationUser
    Public Property Moderated As Boolean
    Public Property Text As String
    Public Property Created As DateTime
End Class

<Table("Picture")>
Public Class Picture
    Inherits Media

End Class

<Table("Video")>
Public Class Video
    Inherits Media

End Class