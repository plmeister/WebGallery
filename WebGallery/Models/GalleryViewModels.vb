Imports System.ComponentModel.DataAnnotations

Public Class GalleryViewModel
    Public Property Name As String
    Public Property CreateDate As DateTime
    Public Property ItemCount As Integer
    Public Property LastItemUploaded As DateTime
    Public Property GalleryId As Integer
End Class

Public Class GalleryDisplayViewModel
    Public Property Name As String
    Public Property Items As List(Of MediaViewModel)
End Class

Public Class MediaViewModel
    Public Property MediaID As Integer
    Public Property Name As String
    Public Property Tags As List(Of TagViewModel)
End Class

Public Class TagViewModel
    Public Property Name As String
    Public Property TagID As Integer
End Class

Public Class CreateGalleryViewModel
    <Required()> Public Property Name As String

End Class

Public Class EditGalleryViewModel
    <Required()> Public Property Name As String
    Public Property GalleryId As Integer
End Class

Public Class DeleteGalleryViewModel
    Public Property GalleryId As Integer
    Public Property Name As String
End Class