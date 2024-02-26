# Add Area

## Create a New Areas `Admin` and `Customer`.

1. **In Visual Studio, `right-click` on your project in the `Solution Explorer`**.

- Select **Add** -> **New Scaffolded Item**.
- Choose `MVC Area` from the list and click **Add**.
- Provide a meaningful name for your area (e.g., "Admin").

2. **Structure the Area Folder**

   - The newly created folder **`(Areas/{AreaName})`** will contain subfolders for `Controllers`, `Models`, and `Views`.
     - This structure helps organize your area's components.

3. **Define the Area Controller**

   - Create a controller class within the Controllers folder (e.g., **`AdminController.cs`**).
   - Add the **`[Area("Admin")]`** attribute above the class declaration to associate it with the "Admin" area.

```c#
using Microsoft.AspNetCore.Mvc;

namespace BuckyBookWeb.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

```

4. **Configure Routing (Optional)**
   - By default, ASP.NET Core automatically routes requests to area controllers based on the URL structure.
   - The area name becomes part of the route template:
   ```c#
       {area}/{controller}/{action}/{id?}
   ```
   - If you need more control over routing, you can use the **`MapAreaControllerRoute`** method in **Program.cs**:
   ```c#
   app.UseEndpoints(endpoints =>
       {
         endpoints.MapControllerRoute(
           name : "areas",
           pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );
       });
   ```

# Restructure the Folder in the Solution.

1.  Move the CategoryController file from Controller to Area/Admin/Controller.
