Imports System.Web.Mvc
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class MyGalleriesController
        Inherits Controller

        Dim ctx As New ApplicationDbContext()

        ' GET: MyGalleries
        <Authorize>
        Function Index() As ActionResult
            Dim x As New MyGalleriesIndex()
            Dim currentUserId As String = User.Identity.GetUserId()
            x.Galleries = ctx.Galleries.
                Where(Function(g) g.Owner.Id = currentUserId).
                Select(Function(g) New GalleryViewModel() With {
                               .Name = g.Name,
                               .CreateDate = g.Created,
                               .ItemCount = g.Items.Count,
                               .GalleryId = g.GalleryID}
                               ).ToList()
            Return View(x)
        End Function

        ' GET: MyGalleries/Details/5
        <Authorize>
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: MyGalleries/Create
        <Authorize>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: MyGalleries/Create
        <Authorize, HttpPost()>
        Function Create(ByVal g As CreateGalleryViewModel) As ActionResult
            Try
                ' TODO: Add insert logic here
                If ModelState.IsValid Then
                    Dim gal As New Gallery() With {
                        .Created = Now,
                        .Name = g.Name,
                        .Owner = ctx.Users.Single(Function(x) x.UserName = User.Identity.Name)
                        }
                    ctx.Galleries.Add(gal)
                    ctx.SaveChanges()

                    Return RedirectToAction("Index")
                End If

                Return View(g)
            Catch
                Return View()
            End Try
        End Function

        ' GET: MyGalleries/Edit/5
        <Authorize>
        Function Edit(ByVal id As Integer) As ActionResult
            Dim g = ctx.Galleries.Find(id)
            Dim eg As New EditGalleryViewModel() With {.Name = g.Name, .GalleryId = g.GalleryID}
            Return View(eg)
        End Function

        ' POST: MyGalleries/Edit/5
        <Authorize, HttpPost()>
        Function Edit(ByVal id As Integer, eg As EditGalleryViewModel) As ActionResult
            Try
                ' TODO: Add update logic here
                If ModelState.IsValid Then
                    Dim g = ctx.Galleries.Find(id)
                    g.Name = eg.Name
                    ctx.SaveChanges()

                    Return RedirectToAction("Index")
                End If

                Return View(eg)
            Catch
                Return View()
            End Try
        End Function

        ' GET: MyGalleries/Delete/5
        <Authorize>
        Function Delete(ByVal id As Integer) As ActionResult
            Dim g = ctx.Galleries.Find(id)
            Return View(New DeleteGalleryViewModel() With {.GalleryId = g.GalleryID, .Name = g.Name})
        End Function

        ' POST: MyGalleries/Delete/5
        <Authorize, HttpPost()>
        Function Delete(ByVal id As Integer, ByVal d As DeleteGalleryViewModel) As ActionResult
            Try
                ' TODO: Add delete logic here
                If ModelState.IsValid Then
                    Dim g = ctx.Galleries.Find(id)
                    ctx.Galleries.Remove(g)
                    ctx.SaveChanges()
                    Return RedirectToAction("Index")
                End If

                Return View(d)
            Catch
                Return View(d)
            End Try
        End Function
    End Class
End Namespace