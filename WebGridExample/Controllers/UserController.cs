using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebGridExample.ActionResults;
using WebGridExample.Formatters;
using WebGridExample.Interface;
using WebGridExample.Models;
using WebGridExample.Repository;
using WebGridExample.ViewModel;

namespace WebGridExample.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController() : this(new UserRepository()) { }
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        #region WebGrid Batch

        // GET: User
        public ActionResult WebGridBatch()
        {
            var model = new WebGridBatchViewModel
            {
                //Users = _repository.GetAll()
                Users = GetUserData()
            };
            return View(model);
    }

    private IEnumerable<User> GetUserData()
    {
        return new List<User>()
                {
                    new User()
                    {
                        FirstName = "1",
                        Id = 1,
                        LastLogin = DateTime.Now,
                        LastName = "Last",
                        UserName = "username"
                    },
                    new User()
                    {
                        FirstName = "1",
                        Id = 1,
                        LastLogin = DateTime.Now,
                        LastName = "Last",
                        UserName = "username"
                    },
                    new User()
                    {
                        FirstName = "1",
                        Id = 1,
                        LastLogin = DateTime.Now,
                        LastName = "Last",
                        UserName = "username"
                    },
                    new User()
                    {
                        FirstName = "1",
                        Id = 1,
                        LastLogin = DateTime.Now,
                        LastName = "Last",
                        UserName = "username"
                    },
                    new User()
                    {
                        FirstName = "1",
                        Id = 1,
                        LastLogin = DateTime.Now,
                        LastName = "Last",
                        UserName = "username"
                    },
                    new User()
                    {
                        FirstName = "1",
                        Id = 1,
                        LastLogin = DateTime.Now,
                        LastName = "Last",
                        UserName = "username"
                    }
                };
    }

    [HttpPost]
    public ActionResult WebGridBatch(WebGridBatchViewModel model)
    {
        if (model.Delete)
        {
            foreach (var user in model.SelectedUsers)
            {
                
            }
        }

        return Redirect(Url.Content("~/"));
    }


    #endregion


    #region WebGrid Inline Editing

    public ActionResult WebGridInlineEditing(int? page)
    {
        var defaultPageSize = 5;
        var model = new WebGridWebApiViewModel
        {
            Users = GetUserData()
        };
        return View(model);
    }

    #endregion

    #region WebGrid Validating

    public ActionResult WebGridValidating(int? page)
    {
        var defaultPageSize = 5;
        var model = new WebGridWebApiViewModel
        {
            Users = _repository.GetPagedUsers(page, defaultPageSize)
        };
        return View(model);
    }

    #endregion

    #region WebGrid Excel Filtering

    public ActionResult WebGridExcelFiltering()
    {
        var model = new WebGridBatchViewModel
        {
            Users = _repository.GetAll()
        };
        return View(model);
    }


    #endregion

}
}