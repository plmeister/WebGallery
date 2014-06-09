<RequireHttps()> Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Dim ctx As New ApplicationDbContext()

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    <Authorize> Function GalleryView(id As Integer) As ActionResult
        Dim g = ctx.Galleries.Find(id)
        Dim gv As New GalleryDisplayViewModel() With {.Name = g.Name, .Items = g.Items.Where(Function(p) p.Moderated = True).Select(Function(p) New MediaViewModel() With {.MediaID = p.Media.MediaID, .Name = p.Media.Name}).ToList()}
        Return View(gv)
    End Function
End Class
